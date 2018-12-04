using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    [SerializeField, Tooltip("Child of this canvas object")]
    Text gemsText;

    [SerializeField, Tooltip("Child of this canvas object")]
    Text gamesPlayed;

    [SerializeField, Tooltip("Child of this canvas object")]
    Text highScore;

    [SerializeField, Tooltip("Child of this canvas object")]
    Text distance;

    [SerializeField, Tooltip("Child of this canvas object")]
    GameObject gameOverPanel;

    [SerializeField, Tooltip("Child of this canvas object")]
    Button soundButton;

    [SerializeField, Tooltip("Ball on the scene")]
    GameObject player;

    [SerializeField]
    Sprite[] soundSprites;

    private Animator animator;
    private float countDistance;

    private void Awake()
    {
        EventManager.EventMenuLoaded += OnMenuLoaded;
        EventManager.EventGameStarted += OnGameStarted;
        EventManager.EventGameOver += OnGameOver;
    }

    private void Start()
    {
        EventManager.RaiseEventMenuLoaded();
        animator = GetComponent<Animator>();

        if (PlayerPrefsManager.IsSoundOn())
        {
            soundButton.GetComponent<Image>().sprite = soundSprites[1];
            AudioListener.volume = 1;
        }
        else if (!PlayerPrefsManager.IsSoundOn())
        {
            soundButton.GetComponent<Image>().sprite = soundSprites[0];
            AudioListener.volume = 0;
        }
    }

    private void Update()
    {
        
        if(player.transform.position.y>countDistance)
        {
            countDistance = Mathf.Round((player.transform.position.y) * 100f) / 100f;
            distance.text = "DISTANCE: " + countDistance.ToString();
        }
    }

    private void OnMenuLoaded()
    {
        // Display UI values
        gemsText.text = PlayerPrefsManager.GetNumberOfGems().ToString();
        gamesPlayed.text = "GAMES PLAYED: " + PlayerPrefsManager.GetGamesPlayed().ToString();
        highScore.text = "HIGH SCORE: " +PlayerPrefsManager.GetHighScore().ToString();

        EventManager.EventMenuLoaded -= OnMenuLoaded;
    }

    private void OnGameStarted()
    {
        animator.SetTrigger("FadeOut");
        EventManager.EventGameStarted -= OnGameStarted;
    }

    private void OnGameOver()
    {
        PlayerPrefsManager.SetGamesPlayed(PlayerPrefsManager.GetGamesPlayed() + 1);
        if (countDistance > PlayerPrefsManager.GetHighScore())
        { PlayerPrefsManager.SetHighScore(countDistance); }

        gameOverPanel.SetActive(true);
        EventManager.EventGameOver -= OnGameOver;
    }

    public void ToggleSound()
    {
        if (Application.platform != RuntimePlatform.Android) { return; }

        if (PlayerPrefsManager.IsSoundOn())
        {
            AudioListener.volume = 0;
            soundButton.GetComponent<Image>().sprite = soundSprites[0];
            PlayerPrefsManager.SetSoundOff();
        }
        else if (!PlayerPrefsManager.IsSoundOn())
        {
            AudioListener.volume = 1;
            soundButton.GetComponent<Image>().sprite = soundSprites[1];
            PlayerPrefsManager.SetSoundOn();
        }
    }
}
