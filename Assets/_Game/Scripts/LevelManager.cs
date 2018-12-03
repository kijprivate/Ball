using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour 
{

    public Ball ballPrefab;

    [SerializeField]
    Sprite[] ballSprites;

	public void QuitRequest()
	{
		Application.Quit ();

	}
	public void LoadLevel(string name)
	{
       SceneManager.LoadScene(name);
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    private void Start()
    {

    }
    private void Awake()
    {
        //if (SceneManager.GetActiveScene().name == "Game")
        //{
        //    if (PlayerPrefsManager.GetChoosenBallNumber() == 0)
        //    { PlayerPrefsManager.ChooseBall(1); }
        //    ballPrefab.GetComponentInChildren<SpriteRenderer>().sprite = ballSprites[PlayerPrefsManager.GetChoosenBallNumber() - 1];
        //    Instantiate(ballPrefab);   
        //}
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name=="Game" && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (SceneManager.GetActiveScene().name == "ChooseBallMenu" && Input.GetKeyDown(KeyCode.Escape))
        {
            LoadLevel("Game");
        }
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
