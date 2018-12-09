using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public bool reloading = false;
	public string weaponName;
	public string weaponType;
	public float damage;
	public float fireRate;
	public float nextShot = 0;
	public Ammo ammo;
	public AudioSource gunShot;
	public Animation anim;
	public ParticleSystem muzzleFlash;
	public GameObject bloodPrefab;
	private Camera fpsCam;

	void Start()
	{
		ammo = GetComponent<Ammo> ();
		fpsCam = GetComponentInParent<Camera> ();
        anim = GetComponent<Animation>();
		muzzleFlash = GetComponentInChildren<ParticleSystem> ();
	}

	public void Shoot()
	{
		ammo.loadedAmmo--;
		if (gunShot)
			gunShot.Play();
		if (anim.GetClip("shoot"))
           anim.Play("shoot");
		if (muzzleFlash && !muzzleFlash.isPlaying)
			muzzleFlash.Play ();
		RaycastHit hit;
		// If we hit something
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit)) 
		{
			// We hit an enemy
			if (hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag == "Boss") 
			{
				// Apply damage to enemy health
				Enemy enemy = hit.transform.gameObject.GetComponentInParent<Enemy> ();
				enemy.health -= damage;
				// Create blood splatter effect
				CreateBlood (hit.point, hit.transform.rotation);
				//  We did enough damage to kill our enemy
				if (enemy.health <= 0)
				{
					enemy.Dead ();
					hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(fpsCam.transform.forward * damage * 60f);
				}
			}
		}
	}
	private void CreateBlood(Vector3 pos, Quaternion rot)
	{
		GameObject blood = Instantiate (bloodPrefab, pos, rot);
		Destroy (blood, 1f);
	}
	public IEnumerator Reload(float reloadTime)
	{
		reloading = true;
		if (anim)
			anim.Play ("reload");
		yield return new WaitForSeconds (reloadTime);
		int ammoToBeAdded = ammo.MAX_LOADED_AMMO - ammo.loadedAmmo;
		if (ammoToBeAdded > ammo.reserveAmmo)
			ammoToBeAdded = ammo.reserveAmmo;
		ammo.loadedAmmo += ammoToBeAdded;
		ammo.reserveAmmo -= ammoToBeAdded;
		reloading = false;
	}
}