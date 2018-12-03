using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour {

    [SerializeField]Button playAgain;

    GameObject ball;
    Ball bal;
    Ball ballDistance;

    public bool isLost=false;

	void Start () {
        ball = GameObject.FindGameObjectWithTag("Player");
        bal = FindObjectOfType<Ball>();
        ballDistance = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == ball)
        {
            bal.transform.position = new Vector3(0, 0, 0);
            bal.isLost = true;

            if (bal.isPlaying)
            {
                PlayerPrefsManager.SetGamesPlayed(PlayerPrefsManager.GetGamesPlayed() + 1);
                if (PlayerPrefsManager.IsSoundOn())
                {
                    bal.GetComponent<AudioSource>().clip = bal.audioClips[1];
                    bal.GetComponent<AudioSource>().volume = 0.7f;
                    bal.GetComponent<AudioSource>().Play();
                }
            }
           
            bal.isPlaying = false;
            if (ballDistance.distance > PlayerPrefsManager.GetHighScore())
            {
                PlayerPrefsManager.SetHighScore(ballDistance.distance);
            }
            
            bal.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            

            int probability = Random.Range(1, 4);
            if (probability == 1 && PlayerPrefsManager.GetGamesPlayed()>10)
            {
                AdManager.Instance.ShowVideo();
            }
        }
    }
}
