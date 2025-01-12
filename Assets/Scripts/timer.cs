using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class timer : MonoBehaviour
{
    public float timeCount = 90;
    public Text timerText;

    public GameObject loseScreen;
    public GameObject winScreen;
    public movement movementScript;

    public Button playAgain;
    public Button returnToMenu;

    public Text finalScoreText;
    private float finalScore;

    private void Awake()
    {
        Time.timeScale = 1;
        timeCount = 90;
    }

    void Start()
    {
        //Debug.LogWarning($"Play Again Button Active: {playAgain.gameObject.activeSelf}");
    }

    void Update()
    {
        // Basic time loop
        if (timeCount > 0)
        {

            timeCount -= Time.deltaTime;
        }
        else
        {
            timeCount = 0;
        }

        DisplayTime(timeCount);

        //if (time <= 0 && movementScript.score < 40)
        //{
        //    DisplayLoseScreen();
        //}

        if (movementScript.score >= 40 && timeCount <= 0)
        {
            DisplayWinScreen();
            DisplayFinalScore();
            DisplayButtons();

            Debug.LogWarning("Score: " + movementScript.score);
            Debug.LogWarning("Time Count: " + timeCount);
        }
        else if (movementScript.score < 40 && timeCount <= 0)
        {
            DisplayLoseScreen();
            DisplayFinalScore();
            DisplayButtons();

            Debug.LogWarning("Score: " + movementScript.score);
            Debug.LogWarning("Time Count: " + timeCount);
        }

        Debug.LogWarning($"AAAAAAAAAAAAAAA: {playAgain.gameObject.activeSelf}");
    }

    void DisplayTime(float timeToDisplay)
    {
        // Will enable game over GUI if value of time is 0
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            Time.timeScale = 0;
        }

        // Sets the minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Sets the text GUI to the structured format 
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void DisplayLoseScreen()
    {
        loseScreen.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
    }

    public void DisplayWinScreen()
    {
        Debug.LogWarning("Final Score:" + finalScore);
        winScreen.SetActive(true);
    }

    private void DisplayFinalScore()
    {
        finalScore = movementScript.score;
        finalScoreText.text = finalScore.ToString();
        finalScoreText.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        Debug.LogWarning("BUTTON CLICKED play again ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Debug.LogWarning("BUTTON CLICKED MENU ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void DisplayButtons()
    {
        playAgain.gameObject.SetActive(true);
        playAgain.interactable = true;

        returnToMenu.gameObject.SetActive(true);
    }
}

// Reference
// AIA (2021). How to EASILY make a TIMER in Unity [online] Available at: https://www.youtube.com/watch?v=27uKJvOpdYw [Accessed 20 Oct 2024]
