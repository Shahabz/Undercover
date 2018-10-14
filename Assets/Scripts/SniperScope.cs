using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScope : MonoBehaviour 
{
	public GameObject fpsCamera;
	public GameObject sniperScope;
	public GameObject crosshair;
	public GameObject gunModel;

	void Start(){
		fpsCamera = GameObject.Find ("FPS Camera");
		sniperScope = GameObject.Find ("Hud").GetComponent<HudDisplay>().sniperScope.gameObject;
		crosshair = GameObject.Find ("Hud").GetComponent<HudDisplay>().crosshair;
	}

	public void applySniperScope()
	{
		fpsCamera.GetComponent<Camera> ().fieldOfView = 30;
		sniperScope.SetActive (true);
		crosshair.SetActive (false);
		// Prevents gun from showing up
		if (gunModel)
			gunModel.SetActive (false);
	}

	public void disableSniperScope()
	{
		fpsCamera.GetComponent<Camera> ().fieldOfView = 60;
		sniperScope.SetActive (false);
		crosshair.SetActive (true);
		if (gunModel)
			gunModel.SetActive (true);
	}
}
