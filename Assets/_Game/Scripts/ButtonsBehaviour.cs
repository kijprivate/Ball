using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsBehaviour : MonoBehaviour {

    Ball ball;
    Image image;
    Color color;
    Button button;

	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		if(ball.isPlaying==true)
        {
            float alpha = image.color.a;
            alpha -= 2f*Time.deltaTime;
            image.color = new Color(1, 1, 1, alpha);

            if(image.color.a<=0)
            {
                image.enabled = false;
                button.enabled = false;
            }
            
        }
	}

}

