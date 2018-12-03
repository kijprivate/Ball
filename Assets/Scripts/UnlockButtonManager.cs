using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButtonManager : MonoBehaviour {

    public int gemCost=25;
    public int ballNumber = 2;

    Text text;
    Image image;
    Color color;
    Button button;
    // Use this for initialization
    void Start () {
        text = GetComponentInChildren<Text>();
        text.text = gemCost.ToString();

        image = GetComponent<Image>();
        button = GetComponent<Button>();

        PlayerPrefsManager.UnlockBall(1);

        if(PlayerPrefsManager.IsBallUnlocked(ballNumber))
        {
            //image.color = new Color(1, 1, 1, 0);
            image.enabled = false;
            text.enabled = false;
            button.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (gemCost < PlayerPrefsManager.GetNumberOfGems() && !PlayerPrefsManager.IsBallUnlocked(ballNumber) && PlayerPrefsManager.IsBallUnlocked(ballNumber-1))
        {
            PlayerPrefsManager.SetNumberOfGems(PlayerPrefsManager.GetNumberOfGems() - gemCost);
            PlayerPrefsManager.UnlockBall(ballNumber);

           // image.color = new Color(1, 1, 1, 0);
            image.enabled = false;
            text.enabled = false;
            button.enabled = false;

        }
    }
}
