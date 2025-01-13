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

    // End game condition screen
    public GameObject loseScreen;
    public GameObject winScreen;

    public Button playAgain;
    public Button returnToMenu;

    // Score display in the end screens
    public Text finalScoreText;
    private float finalScore;

    public movement movementScript;


    private void Awake()
    {
        Time.timeScale = 1;
        timeCount = 90;
    }

    void Start()
    {
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

        // Update the timer display
        DisplayTime(timeCount);

        // Check for win or lose conditions based on score and timer
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
        // Store and display the final score
        finalScore = movementScript.score;
        finalScoreText.text = finalScore.ToString();
        finalScoreText.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        Debug.LogWarning("Play Again Button Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Debug.LogWarning("Menu Button Clicked ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void DisplayButtons()
    {
        // Show and enable the play again and return to menu buttons
        playAgain.gameObject.SetActive(true);
        playAgain.interactable = true;
        returnToMenu.gameObject.SetActive(true);
    }
}

// Reference
// AIA (2021). How to EASILY make a TIMER in Unity [online] Available at: https://www.youtube.com/watch?v=27uKJvOpdYw [Accessed 20 Oct 2024]
