using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamesPlayedDisplay : MonoBehaviour {

    Text text;
	// Use this for initialization
	void Start () {
        text = this.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "GAMES PLAYED: " + PlayerPrefsManager.GetGamesPlayed();
    }
}
