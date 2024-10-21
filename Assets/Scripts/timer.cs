using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float timeCount = 90;
    public Text timerText;
    public GameObject gameOverText;

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
    }

    void DisplayTime(float timeToDisplay)
    {
        // Will enable game over GUI if value of time is 0
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            EndGame();
        }

        // Sets the minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Sets the text GUI to the structured format 
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
    
    public void EndGame()
    {
        gameOverText.SetActive(true);
    }
}

// Reference
// AIA (2021). How to EASILY make a TIMER in Unity [online] Available at: https://www.youtube.com/watch?v=27uKJvOpdYw [Accessed 20 Oct 2024]
