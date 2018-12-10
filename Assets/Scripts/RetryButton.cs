using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public Button retryButton;
    // Use this for initialization
    void Start()
    {
        retryButton.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void TaskOnClick()
    {
		SceneManager.LoadScene (GameManager.levelName);
		/*
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if(sceneName == "CasinoLevel"){
            SceneManager.LoadScene("CasinoLevel");
        }
        else if(sceneName == "SewerLevel"){
            SceneManager.LoadScene("SewerLevel");
        }
        else if(sceneName == "AbandonedSlaughterhouse"){
            SceneManager.LoadScene("AbandonedSlaughterhouse");
        }
        else if(sceneName == "Parkgarage_demo"){
            SceneManager.LoadScene("Parkgarage_demo");
        }
		*/
    }
}