using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billz : MonoBehaviour 
{
	public GameObject moneyArmor;
	public Enemy enemy;
	
	// Update is called once per frame
	void Update () 
	{
		// Break armor
		if (enemy.health <= 100) {
			moneyArmor.SetActive (false);
			// Disable the script
			this.enabled = false;
		}
	}
}
