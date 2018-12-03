using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appear : MonoBehaviour {

    Ball ball;
    Text text;
    Color color;
    // Use this for initialization
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.isPlaying == true)
        {
            float alpha = text.color.a;
            alpha += 2f * Time.deltaTime;
            text.color = new Color(1, 183f/255f, 38f/255f, alpha);

            ChangeColor();
          
        }
    }

    void ChangeColor()
    {
        if (ball.distance < 25f)
        {
            text.color = new Color(1, 183f / 255f, 38f / 255f);
        }
        else if (ball.distance > 25f && ball.distance < 50f)
        {
            text.color = new Color(1, 0, 0);
        }
        else if (ball.distance > 50f && ball.distance < 75f)
        {
            text.color = new Color(91f / 255f, 171f / 255f, 78f / 255f);
        }
        else if (ball.distance > 75f && ball.distance < 100f)
        {
            text.color = new Color(47f / 255f, 86f / 255f, 193f / 255f);
        }
        else if (ball.distance > 100f && ball.distance < 125f)
        {
            text.color = new Color(101f / 255f, 70f / 255f, 92f / 255f);
        }
        else if (ball.distance > 125f && ball.distance < 150f)
        {
            text.color = new Color(180f / 255f, 180f / 255f, 169f / 255f);
        }
        else if (ball.distance > 150f && ball.distance < 175f)
        {
            text.color = new Color(228f / 255f, 228f / 255f, 228f / 255f);
        }
        else if (ball.distance > 175f && ball.distance < 200f)
        {
            text.color = new Color(204f / 255f, 102f / 255f, 242f / 255f);
        }
        else if (ball.distance > 200f && ball.distance < 225f)
        {
            text.color = new Color(228f / 255f, 228f / 255f, 228f / 255f);
        }
        else if (ball.distance > 225f && ball.distance < 250f)
        {
            text.color = new Color(169f / 255f, 234f / 255f, 129f / 255f);
        }
        else if (ball.distance > 250f)
        {
            text.color = new Color(55f / 255f, 55f / 255f, 55f / 255f);
        }
    }
}
