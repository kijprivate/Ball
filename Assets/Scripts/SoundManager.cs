using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager: MonoBehaviour {

    public Chunk[] chunksPrefab;

    Ball ball;
    Image image;
    Color color;
    Button button;

    [SerializeField] Sprite[] soundSprites;
	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        if(PlayerPrefsManager.IsSoundOn())
        {
            image.sprite = soundSprites[0];
            ball.GetComponent<AudioSource>().volume = 1f;
            chunksPrefab[0].GetComponent<AudioSource>().volume = 1f;
            chunksPrefab[1].GetComponent<AudioSource>().volume = 1f;
        }
        if (!PlayerPrefsManager.IsSoundOn())
        {
            image.sprite = soundSprites[1];
            ball.GetComponent<AudioSource>().volume = 0f;
            chunksPrefab[0].GetComponent<AudioSource>().volume = 0f;
            chunksPrefab[1].GetComponent<AudioSource>().volume = 0f;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(ball.isPlaying==true)
        {
            float alpha = image.color.a;
            alpha -= 2f*Time.deltaTime;
            image.color = new Color(1, 1, 1, alpha);

            if(image.color.a<=0)
            {
                image.enabled = false;
                button.enabled = false;
            }
            
        }
	}

    public void ChangeSound()
    {
        if (image.sprite == soundSprites[0])
        {
            image.sprite = soundSprites[1];
            ball.GetComponent<AudioSource>().volume = 0f;
            chunksPrefab[0].GetComponent<AudioSource>().volume = 0f;
            chunksPrefab[1].GetComponent<AudioSource>().volume = 0f;
            PlayerPrefsManager.SetSoundOff();
        }
        else if (image.sprite == soundSprites[1])
        {
            image.sprite = soundSprites[0];
            ball.GetComponent<AudioSource>().volume = 1f;
            chunksPrefab[0].GetComponent<AudioSource>().volume = 1f;
            chunksPrefab[1].GetComponent<AudioSource>().volume = 1f;
            PlayerPrefsManager.SetSoundOn();
        }

    }
}

