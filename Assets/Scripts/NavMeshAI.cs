using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAI : MonoBehaviour
{
	public bool isAttacking = false;
	public bool isHealing = false;
	public bool spottedPlayer = false;
	public bool usesGun = true;
	public float chanceToHit;
	public float distanceDetection;
	public float speed;
	public float angularSpeed;
	public float shootRange;
	public float distanceFromTarget;
	public Animator anim;
	public GameObject player;
	public UnityEngine.AI.NavMeshAgent agent;
	public Weapon enemyWeapon;
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		spottedPlayer = false;	
		speed = agent.speed;
		angularSpeed = agent.speed;
	}
	// Update is called once per frame
	void Update () 
	{
		if (isHealing)
			return;
		if (enemyWeapon.ammo.loadedAmmo == 0 && !enemyWeapon.reloading) {
			Debug.Log ("Enemy is reloading");
			StartCoroutine (enemyWeapon.Reload (2f));
			return;
		}
		distanceFromTarget = Vector3.Distance (player.transform.position, transform.position);
		if (distanceFromTarget < distanceDetection && !spottedPlayer) 
		{
			anim.SetBool ("SpottedPlayer", true);
			anim.SetBool ("CanRun", true);
			spottedPlayer = true;
		}
		if (spottedPlayer)
		{
			if (distanceFromTarget >= 4f) {
				agent.SetDestination (player.transform.position);
			}
			//smoothly rotate the character in the desired direction of motion
			Vector3 lookPos = player.transform.position - transform.position;
			lookPos.y = 0;
			Quaternion rotation = Quaternion.LookRotation(lookPos);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10); 
			CanAttack ();
		}
	}
	void CanAttack()
	{
		if (isAttacking)
			return;

		float shootDistance = Vector3.Distance (player.transform.position, transform.position);
		if (shootDistance <= shootRange) {
			if (Time.time > enemyWeapon.nextShot && !enemyWeapon.reloading && enemyWeapon.ammo.loadedAmmo != 0) {
				enemyWeapon.nextShot = Time.time + enemyWeapon.fireRate;
				Shoot ();
			}
		} 
		else
			StopAttack ();
	}
	void Shoot()
	{
		/*
		RaycastHit hit;
		// Prevent the enemy from shooting if they are in front of a wall
		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			if (hit.transform.tag == "Wall") {
				print ("Enemy facing a wall");
				return;
			}
		}
		*/

		anim.SetTrigger ("Attack");
		anim.SetBool ("CanRun", false);
		agent.speed = 0;
		agent.angularSpeed = 0;
		if (enemyWeapon.muzzleFlash && enemyWeapon.muzzleFlashes.Length <= 0)
			enemyWeapon.muzzleFlash.Play ();
		else if (enemyWeapon.muzzleFlashes.Length != 0) 
		{
			foreach (ParticleSystem flash in enemyWeapon.muzzleFlashes)
				flash.Play();
		}
		if (enemyWeapon.gunShot)
			enemyWeapon.gunShot.Play ();
		enemyWeapon.ammo.loadedAmmo--;
		// This will determine the enemy gun accuracy
		int hitChance = Random.Range(0, 100);
		if (hitChance >= chanceToHit)
			player.GetComponent<PlayerController> ().health -= (int) enemyWeapon.damage;
	}
	public void StopAttack()
	{
		anim.SetBool ("CanRun", true);
		isAttacking = false;
		agent.speed = speed;
		agent.angularSpeed = angularSpeed;
	}
}
