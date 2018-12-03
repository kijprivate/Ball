using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour {

    Ball ball;
    Image image;
    Color color;
    Button button;
    Text text;
    // Use this for initialization
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        image.color =new Color(1,1,1, 0);
        text.color = new Color(1, 1, 1, 0);
        button.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.isLost==true)
        {
            float alpha = image.color.a;
            alpha += 2f * Time.deltaTime;
            image.color = new Color(1, 1, 1, alpha);
            text.color = new Color(1, 1, 1, alpha);
            button.enabled = true;
        }
    }
}
