using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour 
{
	public float health;
	public NavMeshAI ai;
	private Rigidbody[] bodies;
	private bool isDead = false;
	// Use this for initialization
	void Start () 
	{
		if (health == 0)
			health = 100;
		bodies = GetComponentsInChildren<Rigidbody> ();
		SetKinematic (true);
	}

	void SetKinematic(bool isKinematic)
	{
		foreach (Rigidbody bodyPart in bodies)
			bodyPart.isKinematic = isKinematic;
	}
	public void TakeDamage(float damage)
	{
		if (!ai.spottedPlayer && !isDead) {
			ai.anim.SetBool ("SpottedPlayer", true);
			ai.anim.SetBool ("CanRun", true);
			ai.spottedPlayer = true;
		}
		health -= damage;
	}
	public void Dead()
	{
		isDead = true;
		SetKinematic (false);
		enabled = false;
		ai.anim.enabled = false;
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.enabled = false;
		ai.enabled = false;
		// Destroy the enemy after 5 seconds to free up memory --- ONLY IF THEY ARE BASIC ENEMIES
		if (gameObject.tag != "Boss")
			Destroy(gameObject, 5f);
	}
}
