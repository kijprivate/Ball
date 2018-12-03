using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsDisplay : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PlayerPrefsManager.GetNumberOfGems().ToString();
    }
}
