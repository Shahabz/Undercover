using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
	
    public Button backButton;
    // Use this for initialization
    void Start()
    {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
        backButton.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void TaskOnClick()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
