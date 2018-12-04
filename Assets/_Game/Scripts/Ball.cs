using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    [SerializeField]
    private AudioClip[] audioClips;

    Rigidbody2D rigidBody;
    AudioSource audioSource;
    Animator animator;

    Rect bottom=new  Rect(0, 0, Screen.width , 2*Screen.height / 5);
    Rect top = new Rect(0, 2*Screen.height / 5, Screen.width, 3*Screen.height / 5);

    public bool isPlaying = false;
    public bool isLost = false;
    public float distance = 0;

    private void Awake()
    {
        EventManager.EventGameOver += OnGameOver;
        EventManager.EventGameStarted += OnGameStarted;
    }
    void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0f;
        isLost = false;

        //AdManager.Instance.ShowBanner();
    }
	
	void Update ()
    {
        CountingDistance();

        DetermineMenuTouchArea();
    }

    private void CountingDistance()
    {
        if(transform.position.y>distance)
        { distance = Mathf.Round((this.transform.position.y) * 100f) / 100f; }
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

    private void OnGameOver()
    {
        PlayGameOverSound();
        rigidBody.gravityScale = 0f;
        rigidBody.velocity = Vector3.zero;
        //Destroy(this.gameObject);
        EventManager.EventGameOver -= OnGameOver;
    }

    private void OnGameStarted()
    {
        animator.SetTrigger("StartPlaying");
        EventManager.EventGameStarted -= OnGameStarted;
    }
    private void PlayGameOverSound()
    {
        audioSource.clip = audioClips[1];
        audioSource.volume = 0.7f;
        audioSource.Play();
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
