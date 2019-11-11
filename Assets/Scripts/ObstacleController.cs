using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour
{
    public int score;
    private int playerCount;
    private int playerLeft;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeMain"))
        {
            FindObjectOfType<AudioManager>().Play("crash");
            if (other.name == "Snake2")
            {
                score = PlayerPrefs.GetInt("Player1 Score");
                score++;
                Debug.Log("Snake1 score " + score.ToString());
                PlayerPrefs.SetInt("Player1 Score", score);
            }
            else if(other.name == "Snake")
            {
                score = PlayerPrefs.GetInt("Player2 Score");
                score++;
                PlayerPrefs.SetInt("Player2 Score", score);
            }
            

            // Game Over
            playerCount = PlayerPrefs.GetInt("Players");
            if (playerCount > 1)
            {
                Debug.Log("PlayerCount = " + playerCount.ToString());
                playerLeft = PlayerPrefs.GetInt("PlayersLeft");

                if(other.name == "Snake" && PlayerPrefs.GetString("Player1Alive") == "true")
                {
                    playerLeft--;
                    PlayerPrefs.SetString("Player1Alive", "false");
                }
                else if(other.name == "Snake2" && PlayerPrefs.GetString("Player2Alive") == "true")
                {
                    playerLeft--;
                    PlayerPrefs.SetString("Player2Alive", "false");
                }
                else if (other.name == "Snake3" && PlayerPrefs.GetString("Player3Alive") == "true")
                {
                    playerLeft--;
                    PlayerPrefs.SetString("Player3Alive", "false");
                }
                else if (other.name == "Snake4" && PlayerPrefs.GetString("Player4Alive") == "true")
                {
                    playerLeft--;
                    PlayerPrefs.SetString("Player4Alive", "false");
                }
                PlayerPrefs.SetInt("PlayersLeft", playerLeft);
                Destroy(other.gameObject);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}