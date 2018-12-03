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
    Button playAgain;

    [SerializeField, Tooltip("Child of this canvas object")]
    Button share;

    Animator animator;

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
        playAgain.enabled = true;
        share.enabled = true;
        animator.SetTrigger("FadeIn");
        EventManager.EventGameOver -= OnGameOver;
    }
}
