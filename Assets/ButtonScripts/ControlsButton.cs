using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlsButton : MonoBehaviour
{
    public Button controlsButton;
    // Use this for initialization
    void Start()
    {
        controlsButton.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void TaskOnClick()
    {
        SceneManager.LoadScene("ControlsScreen");
    }
}
