using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSewers : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (MoneyManager.currentMoney >= 100)
            {
                SceneManager.LoadScene("SewerLevel");
            }
        }
    }
}