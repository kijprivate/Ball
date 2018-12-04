using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    [SerializeField]
    Transform progressBar;

    [SerializeField]
    Transform noThanks;

    [SerializeField]
    Transform gameOverPanel;

    [SerializeField]
    float currentAmount;

    [SerializeField]
    float speed = 20f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentAmount > 0)
        {
            currentAmount -= speed * Time.deltaTime;
        }
        else
        {
            gameOverPanel.gameObject.SetActive(true);
            progressBar.gameObject.SetActive(false);
        }
        if(currentAmount < 50f)
        { noThanks.gameObject.SetActive(true); }
        progressBar.GetComponent<Image>().fillAmount = currentAmount/100;
	}
}
