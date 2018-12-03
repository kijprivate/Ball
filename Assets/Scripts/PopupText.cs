using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupText : MonoBehaviour {

    public Animator animator;
    Text text;
	// Use this for initialization
	void Start () {

        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length-0.3f);

        text = GetComponentInChildren<Text>();
	}
    private void Update()
    {
       
    }
    public void SetText(int gemValue)
    {
        text.text = "+ "+gemValue;
    }
}
