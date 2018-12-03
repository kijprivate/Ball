using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehaviour : MonoBehaviour {

    Ball ball;
    Text text;
    Color color;
	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ball.isPlaying==true)
        {
            float alpha = text.color.a;
            alpha -= 2f*Time.deltaTime;
            text.color = new Color(1, 1, 1, alpha);

            if(text.color.a<=0)
            {
                text.enabled = false;
            }
            
        }
	}
}

