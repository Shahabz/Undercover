using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckListManager : MonoBehaviour 
{
	public Toggle casinoToggle;
	public Toggle sewerToggle;
	public Toggle parkingToggle;
	public Toggle slaughterToggle;
	// Update is called once per frame
	void Update () {
		if (GameManager.billzDead && casinoToggle.isOn == false && MoneyManager.currentMoney >= 100)
			casinoToggle.isOn = true;
		else if (GameManager.trapzDead && sewerToggle.isOn == false && MoneyManager.currentMoney >= 200)
			sewerToggle.isOn = true;
		else if (GameManager.gunzzDead && GameManager.drugzDead && parkingToggle.isOn == false && MoneyManager.currentMoney >= 300)
			parkingToggle.isOn = true;
		else if (GameManager.clockerzDead && slaughterToggle.isOn == false)
			slaughterToggle.isOn = true;
	}
}
