using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisappear : MonoBehaviour {

    Ball ball;
    Image image;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ball.isPlaying)
        {
            float alpha = image.color.a;
            alpha -= 2f * Time.deltaTime;
            image.color = new Color(1, 1, 1, alpha);

            if (image.color.a <= 0)
            {
                image.enabled = false;
            }
        }
	}
}
