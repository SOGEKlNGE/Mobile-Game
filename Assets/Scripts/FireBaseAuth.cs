using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class FirebaseAuthTester : MonoBehaviour
{
    public InputField emailInputField; 
    public InputField passwordInputField;
    public Text feedbackText;

    public bool isLoggedIn = false;

    public GameObject LoginPanel;
    public GameObject AdsPanel;
    public GameObject SettingsPanel;
    public GameObject mainMenuButtons;
    public GameObject mainMenuBackground;

    private FirebaseAuth auth;


    void Start()
    {
        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
                Debug.LogWarning("Firebase initialized successfully." /* Color.green*/);
            }
            else
            {
                Debug.LogWarning("Could not resolve Firebase dependencies: " + task.Result /*Color.red*/);
            }
        });
    }

    private void Update()
    {
        if (isLoggedIn)
        {
            LoginPanel.SetActive(false);
            AdsPanel.SetActive(true);
            SettingsPanel.SetActive(true);
            mainMenuButtons.SetActive(true);
            mainMenuBackground.SetActive(true);
        }
    }

    public void RegisterUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                FirebaseUser newUser = task.Result.User;
                Debug.LogWarning("Registration successful! Welcome, " + newUser.Email /*Color.green*/);
            }
            else
            {
                Debug.LogWarning("Registration failed: " + task.Exception.GetBaseException().Message /*Color.red*/);
            }
        });
    }

    public void LoginUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                FirebaseUser user = task.Result.User; 
                Debug.LogWarning("Login successful! Welcome back, " + user.Email /*Color.green*/);
                isLoggedIn = true;
            }
            else
            {
                Debug.LogWarning("Login failed: " + task.Exception.GetBaseException().Message /*Color.red*/);
            }
        });
    }


    private void UpdateFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
    }
}