using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour {

    public GameObject popupText;

    public static int gemValue = 1;

    GameObject ball;
    Ball bal;
    Canvas renderCanvas;
    Vector2 spawnPos;
    AudioSource audioSource;

    void Start () {
        ball = GameObject.FindGameObjectWithTag("Player");
        bal = FindObjectOfType<Ball>();
        renderCanvas = FindObjectOfType<Canvas>();
        audioSource=GetComponentInParent<AudioSource>();
        spawnPos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (bal.distance < 25)
        { popupText.GetComponentInChildren<Text>().color = new Color(53f / 255f, 229f / 255f, 53f / 225f); }
        else if (bal.distance > 50f && bal.distance < 100f)
        { popupText.GetComponentInChildren<Text>().color = new Color(251f / 255f, 210f / 255f, 71f / 225f); }
        else if (bal.distance > 100f && bal.distance < 150f)
        { popupText.GetComponentInChildren<Text>().color = new Color(218f / 255f, 37f / 255f, 0); }
        else if (bal.distance > 150f && bal.distance < 200f)
        { popupText.GetComponentInChildren<Text>().color = new Color(207f / 255f, 108f / 255f, 255f / 225f); }
        else if (bal.distance > 200f && bal.distance < 250f)
        { popupText.GetComponentInChildren<Text>().color = new Color(73f / 255f, 227f / 255f, 255f / 225f); }
        else if (bal.distance > 250f)
        { popupText.GetComponentInChildren<Text>().color = new Color(204f / 255f, 204f / 255f, 204f / 225f); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == ball )
        {
            audioSource.Play();

            PlayerPrefsManager.SetNumberOfGems(PlayerPrefsManager.GetNumberOfGems() + gemValue);

            
            TextPopup();

            Destroy(gameObject);
        }
    }

    private void TextPopup()
    {
        //popupText.GetComponentInChildren<Text>().color = Color.blue;
        GameObject newtext = Instantiate(popupText, spawnPos, Quaternion.identity);

        //popupText.GetComponentInChildren<Text>().color = Color.blue;
        newtext.transform.SetParent(renderCanvas.transform, false);
        newtext.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);



        newtext.GetComponentInChildren<Text>().text = "+ " + gemValue;
    }
}
