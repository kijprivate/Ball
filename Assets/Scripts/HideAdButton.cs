using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideAdButton : MonoBehaviour {

    Image image;
    Color color;
    Button button;
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
       
        if (!AdManager.isButtonActive)
        {
            image.color = new Color(1, 1, 1,0);
            button.enabled = false;
        }
    }

}
