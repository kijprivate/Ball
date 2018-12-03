using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NativeShareScript : MonoBehaviour {

    private bool isProcessing = false;
    private bool isFocus = false;

   [SerializeField] Button PlayAgainbutton;
    [SerializeField]Button Sharebutton;
    [SerializeField]GameObject title;

    public void ShareBtnPress()
    {
        if(!isProcessing)
        {
            StartCoroutine(ShareScreenshot());
        }
    }

    IEnumerator ShareScreenshot()
    {
        isProcessing = true;

        Image image1 = PlayAgainbutton.GetComponent<Image>();
        Image image2 = Sharebutton.GetComponent<Image>();
        image1.enabled = false;
        image2.enabled = false;

        Text text1 = PlayAgainbutton.GetComponentInChildren<Text>();
        Text text2 = Sharebutton.GetComponentInChildren<Text>();
        text1.enabled = false;
        text2.enabled = false;

        Image img = title.GetComponent<Image>();
        img.enabled = true;
        img.color = new Color(1, 1, 1, 1);

        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshot("screenshot.png", 2);
        string destination = Path.Combine(Application.persistentDataPath, "screenshot.png");

        yield return new WaitForSecondsRealtime(0.3f);

        if(!Application.isEditor)
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Can you beat my score?");
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share your new score");
            currentActivity.Call("startActivity", chooser);

            yield return new WaitForSecondsRealtime(1);

        }

        yield return new WaitUntil(() => isFocus);
        isProcessing = false;

        image1.enabled = true;
        image2.enabled = true;
        text1.enabled = true;
        text2.enabled = true;
        img.enabled = false;
        img.color = new Color(1, 1, 1, 0);
    }

    private void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }
}
