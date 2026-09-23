using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject startScreen;

    private bool restartingGame = false;

    public Animator ScoreTextAnim;

    private void Start()
    {
        if (restartingGame)
        {
            restartGame();
        }
        else
        {
            // This is the first time opening the game
            Time.timeScale = 0f;
        }
    }

    [ContextMenu("Add Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        ScoreTextAnim.Play("TextUpdate");
        scoreText.text = playerScore.ToString();
    }


    public void playGame()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1;               //Start the game by setting time scale to 1

    }
     
    public void restartGame()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        restartingGame = true;
        Time.timeScale = 1f;

        startScreen.SetActive(false);
        gameObject.SetActive(false);

    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);


    }
}
