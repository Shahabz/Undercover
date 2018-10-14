using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour 
{
	public int moveSpeed = 4;
	public int minDistance = 2;
	public int maxDistance = 12;

	public GameObject player;
	public Weapon enemyWeapon;
	public Vector3 lookPosition;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		lookPosition = new Vector3 (player.transform.position.x, transform.position.y, player.transform.position.z);
		transform.LookAt (lookPosition);
	
		if (Vector3.Distance(transform.position, player.transform.position) >= minDistance)
			// Enemy moves towards player
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		// If the enemy is within the maximum radius of the player, the enemy can shoot
		if (Vector3.Distance(transform.position, player.transform.position) <= maxDistance)
		{
			if (enemyWeapon.ammo.loadedAmmo == 0 && !enemyWeapon.reloading) {
				Debug.Log ("Enemy is reloading");
				StartCoroutine (enemyWeapon.Reload (2f));
			}
			if (Time.time > enemyWeapon.nextShot && !enemyWeapon.reloading && enemyWeapon.ammo.loadedAmmo != 0)
			{
				enemyWeapon.nextShot = Time.time + enemyWeapon.fireRate;
				ShootPlayer ();
			}
		}
	}

	void ShootPlayer()
	{
		// If the enemy weapon has a muzzle flash effect attached to it
		if (enemyWeapon.muzzleFlash)
			enemyWeapon.muzzleFlash.Play ();
		// If the enemy weapon has a gun firing sound attached
		if (enemyWeapon.gunShot)
			enemyWeapon.gunShot.Play ();
		enemyWeapon.ammo.loadedAmmo--;
		// This will determine the enemy gun accuracy
		int hitChance = Random.Range(0, 100);
		if (hitChance >= 50)
			player.GetComponent<PlayerController> ().health -= (int) enemyWeapon.damage;
	}
}
