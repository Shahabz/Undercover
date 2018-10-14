using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
	public bool speedBoost = false, jumpBoost = false;
	void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Powerup") {
			other.gameObject.GetComponent<Powerup> ().ApplyPower (gameObject);
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "WeaponPickup")
			other.gameObject.GetComponent<WeaponPickup> ().equipWeapon ();
	}
}
