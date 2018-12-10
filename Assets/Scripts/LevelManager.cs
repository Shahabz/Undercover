using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
	public Enemy mainBoss;
	public Enemy bonusBoss;

	// Update is called once per frame
	void Update ()
	{
		if (mainBoss.health <= 0)
		{
			if (GameManager.levelName == "CasinoLevel" && !GameManager.billzDead)
				GameManager.billzDead = true;
			else if (GameManager.levelName == "SewerLevel" && !GameManager.trapzDead)
				GameManager.trapzDead = true;
			else if (GameManager.levelName == "Parkgarage")
			{
				GameManager.gunzzDead = true;
				if (bonusBoss.health <= 0)
					GameManager.drugzDead = true;
			} 
			else if (GameManager.levelName == "AbandonedSlaughterhouse") {
				GameManager.clockerzDead = true;
				SceneManager.LoadScene("YouWinScreen");
			}
		}
	}
}
