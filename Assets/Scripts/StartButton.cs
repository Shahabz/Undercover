using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    public Button startButton;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
        startButton.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void TaskOnClick () {
		GameManager.levelName = "CasinoLevel";
        SceneManager.LoadScene("CasinoLevel");
	}
}
