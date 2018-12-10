using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToAbandonedSlaughterhouse : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (MoneyManager.currentMoney >= 200)
            {
                SceneManager.LoadScene("AbandonedSlaughterhouse");
            }
        }
    }
}
