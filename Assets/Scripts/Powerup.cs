using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour 
{
    public string powerupType;

	/* Powerup will spin around - NOT NECESSARY
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.rotation.x, 1, transform.rotation.z);		
	}
	*/

	public void ApplyPower(GameObject player)
	{
		UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ();
		CollisionDetection playerCollision = player.GetComponent<CollisionDetection> ();

		// Player is able to run faster and this powerup is only applied if it has not been picked up yet
		if (powerupType == "SPEED" && !playerCollision.speedBoost) 
		{
			fpsController.m_WalkSpeed *= 2f;
			fpsController.m_RunSpeed *= 2f;
			playerCollision.speedBoost = true;
		}
		// Player is able to jump higher and this powerup is only applied if it has not been picked up yet
		else if (powerupType == "JUMP" && !playerCollision.jumpBoost)
		{
			fpsController.m_JumpSpeed *= 2f;
			playerCollision.jumpBoost = true;
		}
		// Increases the reserve ammo for all equipped weapons to their maximum value
		else if (powerupType == "MAXAMMO")
		{
			WeaponSwitching wepSlots = player.GetComponent<PlayerController> ().weaponHandler;
			foreach (Transform wep in wepSlots.transform)
			{
				if (wep.childCount >= 1) 
				{
					Ammo wepAmmo = wep.GetChild (0).GetComponent<Ammo> ();
					wepAmmo.reserveAmmo = wepAmmo.MAX_RESERVE_AMMO;
				}
			}
		}
	}
}
