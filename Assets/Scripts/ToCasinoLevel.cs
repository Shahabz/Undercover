using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCasinoLevel : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			GameManager.levelName = "CasinoLevel";
            SceneManager.LoadScene("CasinoLevel");
        }
    }
}
