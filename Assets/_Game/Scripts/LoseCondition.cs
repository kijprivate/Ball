using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EventManager.RaiseEventGameOver();

            int probability = Random.Range(1, 4); //todo move to on game over
            if (probability == 1 && PlayerPrefsManager.GetGamesPlayed()>10)
            {
                AdManager.Instance.ShowVideo();
            }
        }
    }
}
