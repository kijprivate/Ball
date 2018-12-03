using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseBallManager : MonoBehaviour {

    public Sprite ballSprite;
    public Ball ballPrefab;

    public int ballNumber = 1;

    SpriteRenderer ballPrefabSprite;
    // Use this for initialization
    void Start () {
        ballPrefabSprite = ballPrefab.GetComponentInChildren<SpriteRenderer>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (PlayerPrefsManager.IsBallUnlocked(ballNumber) || ballNumber==1)
        {
            PlayerPrefsManager.ChooseBall(ballNumber);
            ballPrefabSprite.sprite = ballSprite;
            SceneManager.LoadScene("Game");
        }
    }
}
