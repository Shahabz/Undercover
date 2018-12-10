using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour 
{
	public bool scoped = false;
	public int health;
	public int armor;
	public Weapon currWeapon;
	public WeaponSwitching weaponHandler;

	void Start()
	{
		scoped = false;
		health = 100;
		armor = 0;
		weaponHandler = GetComponentInChildren<WeaponSwitching> ();
	}

	void Update()
	{
		if (health <= 0) {
			print ("dead");
			SceneManager.LoadScene ("GameOverScreen");
		}
		if (currWeapon == null || !currWeapon.transform.parent.gameObject.activeSelf || currWeapon != weaponHandler.currWep.GetComponent<Weapon>())
			currWeapon = weaponHandler.currWep.GetComponent<Weapon>();
		else 
		{
			// The user clicked/hold the right mouse button - button used to aim down sight/scope in
			if (Input.GetButton ("Fire2") && !currWeapon.reloading) 
			{
				// If the weapon they are holding is a sniper and they haven't scoped in yet
				if (currWeapon.weaponType == "Sniper" && !scoped)
				{
					SniperScope scope = currWeapon.gameObject.GetComponent<SniperScope> ();
					scope.applySniperScope ();
					scoped = true;
				}
				/*
				// If our weapon is not a sniper and it has the capabilities to aim down sights
				else if (currWeapon.weaponType != "Sniper" && currWeapon.anim.GetClip("ads")){
					currWeapon.anim.Play ("ads");
				}
				*/
			}
			// Player released the right mouse button
			else if (Input.GetButtonUp ("Fire2") && !currWeapon.reloading) 
			{
				// Get out of the scoped view
				if (currWeapon.weaponType == "Sniper" && scoped)
				{
					SniperScope scope = currWeapon.gameObject.GetComponent<SniperScope> ();
					scope.disableSniperScope ();
					scoped = false;
				}
				/*
				// If our weapon is not a sniper and it has the capabilities to aim down sights
				else if (currWeapon.weaponType != "Sniper" && currWeapon.anim.GetClip("ads")){
					currWeapon.anim.Stop ("ads");
					currWeapon.anim.Play ("idle");
				}
				*/
			}
			if (Input.GetButton("Fire1") && Time.time > currWeapon.nextShot && currWeapon.ammo.loadedAmmo >= 1 && !currWeapon.reloading)
			{
				currWeapon.nextShot = Time.time + currWeapon.fireRate;
				currWeapon.Shoot();
			}
			else if (Input.GetButtonUp("Fire1") || Time.time < currWeapon.nextShot)
			{
				if (currWeapon.muzzleFlash && currWeapon.muzzleFlash.isPlaying)
					currWeapon.muzzleFlash.Stop ();
			}
			// The player can only reload as long as they have ammo in reserve and they have shot at least 1 bullet and they currently aren't reloading
			if (Input.GetButtonDown ("Reload") && !currWeapon.reloading)
			{
				if (currWeapon.ammo.loadedAmmo < currWeapon.ammo.MAX_LOADED_AMMO && currWeapon.ammo.reserveAmmo >= 1)
				{
					currWeapon.reloading = true;
					if (currWeapon.anim) 
						currWeapon.anim.Stop ();
					StartCoroutine(currWeapon.Reload (currWeapon.anim.GetClip ("reload").length));
				}
			}

		}
	}
}
