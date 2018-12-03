using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour {

    public static float barSpeed = 2f;

    Vector2 barPos;
    bool moveRight = true;
	// Use this for initialization
	void Start () {
        barPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (barPos.x >= 2)
        { moveRight = false; }

        if (barPos.x <= -2)
        { moveRight = true; }


        if (barPos.x < 2 && moveRight)
        {
            barPos.x += barSpeed * Time.deltaTime;
            this.transform.position = barPos;
        }
        else if (barPos.x > -2 && !moveRight)
        {
            barPos.x -= barSpeed * Time.deltaTime;
            this.transform.position = barPos;
        }
    }

}

