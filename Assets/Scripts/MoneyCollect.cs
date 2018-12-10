using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollect : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			if (GameManager.levelName == "CasinoLevel" && !GameManager.pickedCasinoMoney) {
				GameManager.pickedCasinoMoney = true;
				AddMoney ();
			} else if (GameManager.levelName == "SewerLevel" && !GameManager.pickedSewerMoney) {
				GameManager.pickedSewerMoney = true;
				AddMoney ();
			} else if (GameManager.levelName == "Parkgarage" && !GameManager.pickedParkMoney) {
				GameManager.pickedParkMoney = true;
				AddMoney ();
			}
			else if (GameManager.levelName == "AbandonedSlaughterhouse" && !GameManager.pickedSlaughterMoney) {
				GameManager.pickedSlaughterMoney = true;
				AddMoney ();
			}
        }
    }
	public void AddMoney()
	{
		MoneyManager.currentMoney += 100;
		GameObject.Destroy(gameObject);
	}
}
