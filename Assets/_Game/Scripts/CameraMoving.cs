using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour {

    Ball ball;

    public float cameraSpeed=1.1f;
	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
        
    }
	
	// Update is called once per frame
	void Update () {
         if(ball.transform.position.y>this.transform.position.y)
         {
            Vector3 camPos = this.transform.position;
            camPos.y += cameraSpeed*Time.deltaTime;
            this.transform.position = new Vector3(0f, camPos.y, -10f);
        }
    }

    void MoveCamera()
    {
        
    }
}
