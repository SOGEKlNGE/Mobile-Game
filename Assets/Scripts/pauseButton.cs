using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private bool isPaused = false;
    
    public Button resumeButton;
    public Button restartButton;
    public Button exitButton;

    // Ensure the pause menu is hidden at the start
    void Start()
    {
        // Ensure the pause menu is hidden at the start
        pauseMenuPanel.SetActive(false);

        // Assign button listeners
        resumeButton.onClick.AddListener(togglePause);  
        restartButton.onClick.AddListener(Restart);    
        exitButton.onClick.AddListener(Exit);        
    }

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
            pauseMenuPanel.SetActive(false);
            isPaused = false;
        }
        else
        {
            // Pause & Update
            Time.timeScale = 0f;
            pauseMenuPanel.SetActive(true);
            isPaused = true;
        }
    }

    public void Restart()
    { 
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}