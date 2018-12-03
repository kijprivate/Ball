using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using admob;

public class AdManager : MonoBehaviour {

	public static AdManager Instance { set; get; }

    public static bool isButtonActive=true;

    bool isVideoPlayed = false;
    bool isRewarded = false;

    public string bannerId;
    public string videoId;
    public string rewardedvideoId;
    public string appID;

    //public string TESTbannerId;
    //public string TESTvideoId;
    //public string TESTrewardedvideoId;

    void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);



#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().initSDK(appID);
        Admob.Instance().initAdmob(bannerId, videoId);
        Admob.Instance().loadInterstitial();
#endif

    }

    public void ShowBanner()
    {
        #if UNITY_EDITOR
        #elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
        #endif
    }

    public void HideBanner()
    {
#if UNITY_EDITOR
         #elif UNITY_ANDROID
        Admob.Instance().removeAllBanner();
#endif
    }

    public void ShowVideo()
    {
#if UNITY_EDITOR
#elif UNITY_ANDROID
        if (Admob.Instance().isInterstitialReady()&& !isVideoPlayed)
        {
            Admob.Instance().showInterstitial();
            isVideoPlayed = true;
        }
        else if(!isVideoPlayed)
        {
            Admob.Instance().loadInterstitial();
            Admob.Instance().showInterstitial();
            isVideoPlayed = true;
        }
#endif
    }
    public void LoadInterstitial()
    {
        if (!Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().loadInterstitial();
        }
    }
    public void ShowRewardedVideo()
    {

        if (Admob.Instance().isRewardedVideoReady())
        {
            isButtonActive = false;
            
            Admob.Instance().showRewardedVideo();
            isRewarded = true;
            Admob.Instance().rewardedVideoEventHandler += AdManager_rewardedVideoEventHandler;
        }
        else
        {
            Admob.Instance().loadRewardedVideo(rewardedvideoId);
        }
    }

    private void AdManager_rewardedVideoEventHandler(string eventName, string msg)
    {
        if (eventName == AdmobEvent.onRewardedVideoCompleted&&isRewarded)
        {
            PlayerPrefsManager.SetNumberOfGems(PlayerPrefsManager.GetNumberOfGems() + 40);
            isRewarded = false;
        }
        Debug.Log("Event: " + eventName);
    }

    public void LoadRewardedVideo()
    {
        Admob.Instance().loadRewardedVideo(rewardedvideoId);
    }

}
