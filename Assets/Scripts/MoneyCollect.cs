using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollect : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MoneyManager.currentMoney += 100;
            GameObject.Destroy(gameObject);
        }
    }
}
