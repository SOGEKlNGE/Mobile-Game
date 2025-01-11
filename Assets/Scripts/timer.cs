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

    public Text finalScoreText;
    private float finalScore;

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
        }
        else if (movementScript.score < 40 && timeCount <= 0)
        {
            DisplayLoseScreen();
        }

        Debug.LogWarning("Score: " + movementScript.score);
        Debug.LogWarning("Time Count: " + timeCount);
    }

    void DisplayTime(float timeToDisplay)
    {
        // Will enable game over GUI if value of time is 0
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
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
        finalScore = movementScript.score;
        finalScoreText.text = finalScore.ToString();
        Debug.LogWarning("Final Score:" + finalScore);
        winScreen.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

// Reference
// AIA (2021). How to EASILY make a TIMER in Unity [online] Available at: https://www.youtube.com/watch?v=27uKJvOpdYw [Accessed 20 Oct 2024]
