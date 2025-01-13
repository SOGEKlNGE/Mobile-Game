using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private bool isPaused = false;
    
    public Button resumeButton;
    public Button restartButton;
    public Button exitButton;

    void Start()
    {
        // Button listeners
        resumeButton.onClick.AddListener(togglePause);  
        restartButton.onClick.AddListener(Restart);    
        exitButton.onClick.AddListener(Exit);
    }

    void Update()
    { 
        
    }

    public void togglePause()
    {
        // Check if the game is paused
        if (isPaused)
        {
            // Resume the game by unpausing time and hiding the pause menu
            Time.timeScale = 1f;
            pauseMenuPanel.SetActive(false);
            isPaused = false;
        }
        else
        {
            // Pause the game by stopping time and showing the pause menu
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void Restart()
    {
        // Reset time scale
        Time.timeScale = 1f;

        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        // Reset time scale
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

// Reference
// BMo (2020). 6 Minute PAUSE MENU Unity Tutorial. [online] Available at: https://www.youtube.com/watch?v=9dYDBomQpBQ. [Accessed 20 Oct 2024]



