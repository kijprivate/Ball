using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public AudioClip[] audioClips;

    Rigidbody2D rigidBody;
    AudioSource audioSource;
    bool isMovingDown = true;
    Rect bottom=new  Rect(0, 0, Screen.width , 2*Screen.height / 5);
    Rect top = new Rect(0, 2*Screen.height / 5, Screen.width, 3*Screen.height / 5);

    public bool isPlaying = false;
    public bool isLost = false;
    public float distance = 0;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0f;
        isLost = false;

        //AdManager.Instance.ShowBanner();
    }
	
	// Update is called once per frame
	void Update ()
    {
        BallMenuAnimation();

        CountingDistance();

        DetermineMenuTouchArea();

    }

    private void CountingDistance()
    {
        if (transform.position.y > distance)
        {
            distance = Mathf.Round(this.transform.position.y * 100f) / 100f;
        }
    }

    private void DetermineMenuTouchArea()
    {
        if (!isPlaying)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (top.Contains(Input.GetTouch(0).position))
                {
                    isPlaying = true;
                    rigidBody.gravityScale = 1f;
                    rigidBody.velocity = new Vector2(0, 4f);
                    if (audioSource.clip.name == "Tap")
                    {
                        audioSource.Play();
                    }
                   // EventManager.RaiseEventGameStarted();
                    AdManager.isButtonActive = true;
                //    AdManager.Instance.LoadInterstitial();
                }
            }
        }
        else if (isPlaying)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rigidBody.velocity = new Vector2(0, 4f);
                if (audioSource.clip.name == "Tap")
                {
                    audioSource.Play();
                }
            }
        }
    }

    private void BallMenuAnimation()
    {
        if (!isPlaying)
        {
            if (this.transform.position.y <= -0.66)
            {
                isMovingDown = false;
            }
            if (this.transform.position.y >= 0)
            {
                isMovingDown = true;
            }

            if (this.transform.position.y >= -0.66 && isMovingDown)
            {
                Vector2 ballPos = this.transform.position;
                ballPos.y -= 0.7f * Time.deltaTime;
                this.transform.position = ballPos;
            }
            else if (this.transform.position.y <= 0 && !isMovingDown)
            {
                Vector2 ballPos = this.transform.position;
                ballPos.y += 0.7f * Time.deltaTime;
                this.transform.position = ballPos;
            }

        }
    }

#if UNITY_EDITOR_WIN
    private void OnMouseDown()
    {
        if (top.Contains(Input.mousePosition))
        {
            isPlaying = true;
            rigidBody.gravityScale = 1f;
            rigidBody.velocity = new Vector2(0, 4f);
            audioSource.Play();
            EventManager.RaiseEventGameStarted();
        }
    }
#endif
}
