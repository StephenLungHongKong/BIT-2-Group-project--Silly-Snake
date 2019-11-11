using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementScript : MonoBehaviour {

    public string HorizontalAxis;
    public float moveSpeed;
    public float RotationSpeed;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    public GameObject TailPrefab;
    public GameObject VictoryCanvas;
    public float z_offset = 0.5f;
    public Text ScoreText;
    public Text Player1Score;
    public Text Player2Score;
    public Text WhoWon;
    public Text HighestEasy;
    public Text HighestMedium;
    public Text HighestHard;
    public int score;
    public int player1score;
    public int player2score;

    public List<GameObject> tailObjects = new List<GameObject>();

     void Start()
     {
        if(VictoryCanvas != null)
        {
            VictoryCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        if(HighestEasy != null)
        {
            HighestEasy.text = PlayerPrefs.GetInt("HighestEasy Score").ToString();
        }
        else if (HighestMedium != null)
        {
            HighestMedium.text = PlayerPrefs.GetInt("HighestMedium Score").ToString();
        }
        else if (HighestHard != null)
        {
            HighestHard.text = PlayerPrefs.GetInt("HighestHard Score").ToString();
        }
        score = 0;
        PlayerPrefs.SetInt("PlayersLeft", PlayerPrefs.GetInt("Players"));
        PlayerPrefs.SetString("Player1Alive","true");
        PlayerPrefs.SetString("Player2Alive", "true");
        PlayerPrefs.SetString("Player3Alive", "true");
        PlayerPrefs.SetString("Player4Alive", "true");
        tailObjects.Add(gameObject);
     }

    void Update()
    {
        UpdateScore();
        if(VictoryCanvas != null)
        {
            Victory();
        }
        // Player move along the planet

        transform.Translate(0, 0, moveSpeed * Time.deltaTime);



        if (Input.GetAxisRaw(HorizontalAxis) > 0)
        {
            transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetAxisRaw(HorizontalAxis) < 0)
        {
            transform.Rotate(0, -1 * RotationSpeed * Time.deltaTime, 0);
        }
    }

    public void AddTail()
    {
        score++;
        if (HighestEasy != null)
        {
            if(score > PlayerPrefs.GetInt("HighestEasy Score"))
            {
                PlayerPrefs.SetInt("HighestEasy Score", score);
            }
        }
        else if (HighestMedium != null)
        {
            if (score > PlayerPrefs.GetInt("HighestMedium Score"))
            {
                PlayerPrefs.SetInt("HighestMedium Score", score);
            }
        }
        else if (HighestHard != null)
        {
            if (score > PlayerPrefs.GetInt("HighestHard Score"))
            {
                PlayerPrefs.SetInt("HighestHard Score", score);
            }
        }
        PlayerPrefs.SetInt("Player Score",score);
        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= z_offset;
        GameObject tail = (GameObject)Instantiate(TailPrefab, newTailPos, Quaternion.identity);
        tailObjects.Add(tail);
        TailMovement tm = tail.GetComponent<TailMovement>();
        tm.mainSnake = this;
    }


    public void UpdateScore()
    {
        if (Player1Score != null)
        {
            //Debug.Log("Change Score 1");
            player1score = PlayerPrefs.GetInt("Player1 Score");
            Player1Score.text = player1score.ToString();
        }
        if (Player2Score != null)
        {
            //Debug.Log("Change Score 2");
            player2score = PlayerPrefs.GetInt("Player2 Score");
            Player2Score.text = player2score.ToString();
        }
        if (ScoreText != null)
        {
            //Debug.Log("Change Score");
            ScoreText.text = score.ToString();
        } 
    }

    public void Victory()
    {
        if (PlayerPrefs.GetInt("PlayersLeft") <= 1)
        {
            if (PlayerPrefs.GetString("Player1Alive") == "true")
            {
                WhoWon.text = "One";
            }
            else if (PlayerPrefs.GetString("Player2Alive") == "true")
            {
                WhoWon.text = "Two";
            }
            else if (PlayerPrefs.GetString("Player3Alive") == "true")
            {
                WhoWon.text = "Three";
            }
            else if (PlayerPrefs.GetString("Player4Alive") == "true")
            {
                WhoWon.text = "Four";
            }

            VictoryCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Tail")
        {
            FindObjectOfType<AudioManager>().Play("game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
