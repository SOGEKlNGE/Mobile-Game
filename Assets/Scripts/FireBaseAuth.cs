using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class FirebaseAuthTester : MonoBehaviour
{
    public InputField emailInputField; 
    public InputField passwordInputField;
    public Text feedbackText; 

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

    public void RegisterUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                FirebaseUser newUser = task.Result.User; // Extract the FirebaseUser from AuthResult
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
                FirebaseUser user = task.Result.User; // Extract the FirebaseUser from AuthResult
                Debug.LogWarning("Login successful! Welcome back, " + user.Email /*Color.green*/);
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