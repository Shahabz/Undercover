using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    public Button creditsButton;
    // Use this for initialization
    void Start()
    {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
        creditsButton.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void TaskOnClick()
    {
        SceneManager.LoadScene("CreditsScreen");
    }
}
