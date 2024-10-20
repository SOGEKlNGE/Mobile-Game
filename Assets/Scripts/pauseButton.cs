using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Check for shake input
        if (Input.acceleration.magnitude > 2.2f) 
        {
            togglePause(); 
        }
    }


    public void togglePause()
    {
        // Check if the game is paused
        if (isPaused)
        {
            // Resume & Update
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            // Pause & Update
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

}