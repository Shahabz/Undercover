using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour 
{
	public GameObject weaponPrefab;
	public GameObject weaponHandler;
	public string weaponType;

	public void equipWeapon()
	{
		foreach (Transform wepSlot in weaponHandler.transform) 
		{
			if (wepSlot.name == weaponType && wepSlot.childCount < 1) 
			{
				Instantiate (weaponPrefab, wepSlot);
				Destroy (gameObject);
			}
		}
	}
}
