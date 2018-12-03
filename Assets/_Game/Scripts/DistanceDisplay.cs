using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplay : MonoBehaviour {

    Text text;
    Ball ball;
	// Use this for initialization
	void Start () {
        text = this.GetComponent<Text>();
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "DISTANCE: " + ball.distance;
	}
}
