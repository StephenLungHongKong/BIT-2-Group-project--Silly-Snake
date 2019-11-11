﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeadCaugthTail : MonoBehaviour
{
    // Start is called before the first frame update
    public string SnakeName;
    public GameObject snake;

    private int score;
    private int playerCount;
    private int playerLeft;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hitting something");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Tail")
        {
            FindObjectOfType<AudioManager>().Play("game over");
            if (SnakeName == "Snake2")
            {
                score = PlayerPrefs.GetInt("Player1 Score");
                score++;
                Debug.Log("Snake1 score " + score.ToString());
                PlayerPrefs.SetInt("Player1 Score", score);
            }
            else if (SnakeName == "Snake")
            {
                score = PlayerPrefs.GetInt("Player2 Score");
                score++;
                PlayerPrefs.SetInt("Player2 Score", score);
            }

            // Game Over !!
            playerCount = PlayerPrefs.GetInt("Players");
            if (playerCount > 1)
            {
                playerLeft = PlayerPrefs.GetInt("PlayersLeft");
                
                    

                if (snake.name == "Snake" && PlayerPrefs.GetString("Player1Alive") == "true")
                {
                    playerLeft--;
                    PlayerPrefs.SetString("Player1Alive", "false");
                }
                else if (snake.name == "Snake2" && PlayerPrefs.GetString("Player2Alive") == "true")
                {
                    playerLeft--;
                    PlayerPrefs.SetString("Player2Alive", "false");
                }
                else if (snake.name == "Snake3" && PlayerPrefs.GetString("Player3Alive") == "true")
                {
                    playerLeft--;
                    PlayerPrefs.SetString("Player3Alive", "false");
                }
                else if (snake.name == "Snake4" && PlayerPrefs.GetString("Player4Alive") == "true")
                {
                    playerLeft--;
                    PlayerPrefs.SetString("Player4Alive", "false");
                }
                PlayerPrefs.SetInt("PlayersLeft", playerLeft);
                Destroy(snake);
                
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
