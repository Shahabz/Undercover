﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAI : MonoBehaviour
{
	public bool isAttacking = false;
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
		spottedPlayer = false;	
		speed = agent.speed;
		angularSpeed = agent.speed;
	}
	// Update is called once per frame
	void Update () 
	{
		if (enemyWeapon.ammo.loadedAmmo == 0 && !enemyWeapon.reloading) {
			Debug.Log ("Enemy is reloading");
			StartCoroutine (enemyWeapon.Reload (2f));
			return;
		}
		distanceFromTarget = Vector3.Distance (player.transform.position, transform.position);
		if (distanceFromTarget < 14 && !spottedPlayer) 
		{
			anim.SetBool ("spottedPlayer", true);
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
		anim.SetTrigger ("Attack");
		anim.SetBool ("CanRun", false);
		agent.speed = 0;
		agent.angularSpeed = 0;
		if (enemyWeapon.muzzleFlash)
			enemyWeapon.muzzleFlash.Play ();
		if (enemyWeapon.gunShot)
			enemyWeapon.gunShot.Play ();
		enemyWeapon.ammo.loadedAmmo--;
		// This will determine the enemy gun accuracy
		int hitChance = Random.Range(0, 100);
		if (hitChance >= chanceToHit)
			player.GetComponent<PlayerController> ().health -= (int) enemyWeapon.damage;
	}
	void StopAttack()
	{
		anim.SetBool ("CanRun", true);
		isAttacking = false;
		agent.speed = speed;
		agent.angularSpeed = angularSpeed;
	}
}
