using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Ball : MonoBehaviour {

    public float distance = 0;
    public bool isPlaying = false;

    [SerializeField]
    private AudioClip[] audioClips;

    Rigidbody2D rigidBody;
    AudioSource audioSource;
    Animator animator;

    // Rect bottom=new  Rect(0, 0, Screen.width , 2*Screen.height / 5);
    Rect top = new Rect(0, 2 * Screen.height / 5, Screen.width, 3 * Screen.height / 5);

    private bool gameOver = false;

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
        gameOver = false;

        
        //AdManager.Instance.ShowBanner();
    }
	
	void Update ()
    {
        if (gameOver) { return; }

        SetTouchArea();
        CountingDistance();
        Tap();
    }

    private void CountingDistance()
    {
        if(transform.position.y>distance)
        { distance = Mathf.Round((this.transform.position.y) * 100f) / 100f; }
    }

    private void SetTouchArea()
    {
        if (isPlaying) { return; }
        if (Input.GetMouseButtonDown(0) && top.Contains(Input.mousePosition))
        {
            EventManager.RaiseEventGameStarted();
            isPlaying = true;
            rigidBody.gravityScale = 1f;
            rigidBody.velocity = new Vector2(0, 4f);
            if (audioSource.clip.name == "Tap")
            {
                audioSource.Play();
            }
        }
    }

    private void Tap()
    {
        if (!isPlaying) { return; }
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = new Vector2(0, 4f);
            if (audioSource.clip.name == "Tap")
            {
                audioSource.Play();
            }
        }
    }

    private void OnGameOver()
    {
        gameOver = true;
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
}
