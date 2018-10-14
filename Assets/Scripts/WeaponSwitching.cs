using UnityEngine;
/*
 * Weapon Slot Indexes:
 * 	0	Pistol
 *  1	SMG
 *  2	Shotgun
 *  3	Rifle
 *  4	Sniper
 *  5	Heavy Weapons (Ex. Miniguns, Rocket launchers)
 */
public class WeaponSwitching : MonoBehaviour 
{
	// Default the current weapon equipped to pistol slot
	int currWepIDX = 0;
	public GameObject currWep;
	// Use this for initialization
	void Start () {
		// We always want to default to PISTOL slot in the case that the idx value is changed in the inspector
		// to a weapon that we don't have equipped. The pistol will always be equipped.
		Swap (0);
	}
	// Update is called once per frame
	void Update ()
	{
		// Handles weapon swapping by numbers on keyboard
		if (Input.GetKeyDown ("1") && !isWeaponSlotEmpty (0))
			// Pistol 
			Swap (0);
		else if (Input.GetKeyDown ("2") && !isWeaponSlotEmpty (1))
			// SMGS
			Swap (1);
		else if (Input.GetKeyDown ("3") && !isWeaponSlotEmpty (2))
			// Shotguns
			Swap (2);
		else if (Input.GetKeyDown ("4") && !isWeaponSlotEmpty (3))
			// Rifles
			Swap (3);
		else if (Input.GetKeyDown ("5") && !isWeaponSlotEmpty (4))
			// Snipers
			Swap (4);
		else if (Input.GetKeyDown ("6") && !isWeaponSlotEmpty (5))
			// Heavy Weapons
			Swap (5);
		
		//Handles weapon swapping by mouse scrollwheel
		// Mouse Scrollwheel up
		if (Input.GetAxis ("Mouse ScrollWheel") > 0f) 
		{
			// We can only swap if we have equipped at least 2 weapons
			if (transform.childCount > 1) 
				MouseWheelSwap (1, transform.childCount - 1, 0);
		}
		// Mouse Scrollwheel down
		if (Input.GetAxis ("Mouse ScrollWheel") < 0f)
		{
			// We can only swap if we have equipped at least 2 weapons
			if (transform.childCount > 1) 
				MouseWheelSwap (-1, 0, transform.childCount - 1);
		}
	}
	void MouseWheelSwap(int addVal, int atMinOrMaxSlot, int setNextVal)
	{
		// If we are at the beginning of the weapon slot, we want to go to the end
		// Otherwise, we are at the end of the weapon slot and want to go back to the end
		if (currWepIDX == atMinOrMaxSlot)
			currWepIDX = setNextVal;
		// The add value will be 1 if we are scrolling up, otherwise it will be -1 for scrolling down on the mousewheel
		else
			currWepIDX += addVal;
		// Keep searching through the weapon inventory to find the next equipped weapon
		while (isWeaponSlotEmpty (currWepIDX)) 
		{
			if (currWepIDX == atMinOrMaxSlot)
				currWepIDX = setNextVal;
			else
				currWepIDX += addVal;
		}
		Swap (currWepIDX);
	}
	void Swap(int wep)
	{
		int i = 0;
		// Iterate through each of the weapon slots
		foreach (Transform t in transform) 
		{
			if (i == wep) 
			{
				t.gameObject.SetActive (true);
				currWepIDX = wep; 
				currWep = t.GetChild(0).gameObject;
			}
			else
				t.gameObject.SetActive (false);
			// Advance to the next weapon slot
			i++;
		}
	}
	bool isWeaponSlotEmpty(int wep)
	{
		int i = 0;
		foreach (Transform wepSlot in transform)
		{
			// Found the weapon slot and we have a weapon of that type equipped
			if (i == wep && wepSlot.childCount >= 1)
				return false;
			// Found the weapon slot but we don't currently have a weapon of that type equipped
			else if (i == wep && wepSlot.childCount < 1)
				return true;
			i++;
		}
		// Return true by default
		return true;
	}
}
