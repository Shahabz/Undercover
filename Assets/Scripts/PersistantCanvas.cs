using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistantCanvas : MonoBehaviour {

    public Text text;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        text.text = "Cash: " + MoneyManager.currentMoney;
    }
}
