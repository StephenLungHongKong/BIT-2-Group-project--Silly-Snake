using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenu : MonoBehaviour
{
    public Text easyScore;
    public Text mediumScore;
    public Text hardScore;


    private Animator anim;
    private void Start()
    {
        if(easyScore != null)
        {
            easyScore.text = PlayerPrefs.GetInt("HighestEasy Score").ToString();
        }
        if (easyScore != null)
        {
            mediumScore.text = PlayerPrefs.GetInt("HighestMedium Score").ToString();
        }
        if (easyScore != null)
        {
            hardScore.text = PlayerPrefs.GetInt("HighestHard Score").ToString();
        }       
        Time.timeScale = 1f;
        anim = GetComponent<Animator>();
    }

    public void SinglePlayer()
    {
        PlayerPrefs.SetInt("Players", 1);
        PlayerPrefs.SetInt("PlayersLeft", 1);
        anim.SetTrigger("SinglePlayer");
    }

    public void MultiPlayer()
    {
        anim.SetTrigger("Multiplayer");
    }

    public void SinglePlayerEasy()
    {
        
        SceneManager.LoadSceneAsync("SinglePlayer - Easy");
    }

    public void SinglePlayerMedium()
    {
        SceneManager.LoadSceneAsync("SinglePlayer - Medium");
    }

    public void SinglePlayerHard()
    {
        SceneManager.LoadSceneAsync("SinglePlayer - Hard");
    }

    public void MultiPlayer2()
    {

        PlayerPrefs.SetInt("Players", 2);
        PlayerPrefs.SetInt("Player1 Score", 0);
        PlayerPrefs.SetInt("Player2 Score", 0);
        PlayerPrefs.SetInt("Players", 0);
        PlayerPrefs.SetInt("PlayersLeft", 0);
        SceneManager.LoadSceneAsync("MultiPlayer - 2");
    }

    public void MultiPlayer3()
    {

        PlayerPrefs.SetInt("Players", 3);
        PlayerPrefs.SetInt("PlayersLeft", 3);
        SceneManager.LoadSceneAsync("MultiPlayer - 3");
    }

    public void MultiPlayer4()
    {

        PlayerPrefs.SetInt("Players", 4);
        PlayerPrefs.SetInt("PlayersLeft", 4);
        SceneManager.LoadSceneAsync("MultiPlayer - 4");
    }

    public void MainMenu()
    {
        
        SceneManager.LoadSceneAsync("TitleMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        anim.SetTrigger("Main");
    }
}
