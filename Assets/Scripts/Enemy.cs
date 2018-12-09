using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public float health;
	public NavMeshAI ai;
	private Rigidbody[] bodies;
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

	public void Dead()
	{
		SetKinematic (false);
		enabled = false;
		ai.anim.enabled = false;
		ai.enabled = false;
		// Destroy the enemy after 5 seconds to free up memory
		Destroy(gameObject, 5f);
	}
}
