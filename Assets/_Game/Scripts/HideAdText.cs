using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideAdText : MonoBehaviour {

    Text text;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!AdManager.isButtonActive)
        {
            text.color = new Color(1, 1, 1, 0);
            text.enabled = false;
        }
    }
}
