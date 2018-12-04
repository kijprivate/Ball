using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{

    //const string MASTER_VOLUME_KEY="master_volume";
    //const string DIFFICULTY_KEY="difficulty";


    const string BALL_KEY = "ball_unlocked_";
    const string CHOSEN_BALL_KEY = "chosen_ball_key_";

    const string NUMBER_GEMS = "number of gems";
    const string HIGH_SCORE = "high score";
    const string GAMES_PLAYED = "games played";
    const string REWARDED_PLAYED = "rewarded played";
    const string SOUND_ON = "sound_on";

    public static void SetNumberOfGems(int value)
    {
        PlayerPrefs.SetInt(NUMBER_GEMS, value);
    }

    public static int GetNumberOfGems()
    {
        return PlayerPrefs.GetInt(NUMBER_GEMS);
    }

    public static void SetHighScore(float value)
    {
        PlayerPrefs.SetFloat(HIGH_SCORE, value);
    }

    public static float GetHighScore()
    {
        return PlayerPrefs.GetFloat(HIGH_SCORE);
    }
    public static void SetGamesPlayed(int value)
    {
        PlayerPrefs.SetInt(GAMES_PLAYED, value);
    }

    public static int GetGamesPlayed()
    {
        return PlayerPrefs.GetInt(GAMES_PLAYED);
    }

    public static void UnlockBall(int ballNumber)
    {
        PlayerPrefs.SetInt(BALL_KEY + ballNumber.ToString(), 1);

    }
    public static void SetSoundOn()
    {
        PlayerPrefs.SetInt(SOUND_ON, 1);

    }
    public static void SetSoundOff()
    {
        PlayerPrefs.SetInt(SOUND_ON, 0);

    }
    public static bool IsSoundOn()
    {
        int get = PlayerPrefs.GetInt(SOUND_ON);
        bool isSoundOn = (get == 1);

        return isSoundOn;

    }
    //public static void LockAllBalls()
    //{
    //    for (int i = 2; i < 30; i++)
    //        PlayerPrefs.SetInt(BALL_KEY + i.ToString(), 0);

    //}
    public static bool IsBallUnlocked(int ballNumber)
    {
        int ballValue = PlayerPrefs.GetInt(BALL_KEY + ballNumber.ToString());
        bool isBallUnlocked = (ballValue == 1);

        return isBallUnlocked;

    }
    public static void ChooseBall(int ballNumber)
    {
        PlayerPrefs.SetInt(CHOSEN_BALL_KEY, ballNumber);
    }
    public static int GetChoosenBallNumber()
    {
       return PlayerPrefs.GetInt(CHOSEN_BALL_KEY);
    }

}
