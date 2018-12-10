using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drugz : MonoBehaviour 
{
	public NavMeshAI ai;
	public Enemy enemy;
	float healLength;
	public GameObject cigar;
	public bool healed = false;
	public AudioSource smokeSound;
	void Start()
	{
		RuntimeAnimatorController ac = ai.anim.runtimeAnimatorController;   //Get Animator controller
		for(int i = 0; i<ac.animationClips.Length; i++)                 //For all animations
		{
			if(ac.animationClips[i].name == "Drinking")        //If it has the same name as your clip
			{
				healLength = ac.animationClips[i].length;
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (enemy.health <= 0) {
			smokeSound.Stop ();
			this.enabled = false;
		}
		if (enemy.health < 45 && !healed) {
			healed = true;
			StartCoroutine ("Healing");
		}
	}
	IEnumerator Healing()
	{
		cigar.SetActive (true);
		ai.isHealing = true;
		ai.anim.SetBool ("CanRun", false);
		ai.agent.speed = 0;
		ai.agent.angularSpeed = 0;
		ai.anim.SetTrigger ("Heal");
		yield return new WaitForSeconds (2.5f);
		smokeSound.Play ();
		yield return new WaitForSeconds (5.3f);
		cigar.SetActive (false);
		ai.anim.SetBool ("Heal", false);
		enemy.health += 50f;
		ai.isHealing = false;
		ai.StopAttack ();
	}
}
