using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name=="Game" && Input.GetKeyDown(KeyCode.Escape))
        {
            QuitRequest();
        }
    }

    public void QuitRequest()
    {
        Application.Quit();

    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    //testing

    //public void AddGems()
    //{
    //    PlayerPrefsManager.SetNumberOfGems(PlayerPrefsManager.GetNumberOfGems() + 1000);
    //}

    //public void LockAllBalls()
    //{
    //    PlayerPrefsManager.LockAllBalls();
    //}


}
