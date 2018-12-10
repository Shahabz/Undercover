using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToParkgarage : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (MoneyManager.currentMoney >= 300)
            {
				GameManager.levelName = "Parkgarage";
                SceneManager.LoadScene("Parkgarage");
            }
        }
    }
}
