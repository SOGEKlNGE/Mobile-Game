using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class FirebaseAuthTester : MonoBehaviour
{
    // [GUI]
    public GameObject LoginPanel;
    public GameObject AdsPanel;
    public GameObject SettingsPanel;
    public GameObject mainMenuButtons;
    public GameObject mainMenuBackground;
    public Text feedbackText;

    // [Player Input]
    public InputField emailInputField;
    public InputField passwordInputField;

    // [Flags]
    private bool? regSuccess;
    private bool? loginSuccess;
    public bool isLoggedIn = false;

    private FirebaseAuth auth;

    void Start()
    {
        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
                Debug.LogWarning("Firebase initialized successfully.");
            }
            else
            {
                Debug.LogWarning("Could not resolve Firebase dependencies: " + task.Result);
            }
        });

    }

    private void Update()
    {
        // Show and Hide UI panels based on login status
        if (isLoggedIn)
        {
            LoginPanel.SetActive(false);
            AdsPanel.SetActive(true);
            SettingsPanel.SetActive(true);
            mainMenuButtons.SetActive(true);
            mainMenuBackground.SetActive(true);
        }

        // Display feedback text for registration status
        if (regSuccess == true)
        {
            feedbackText.text = "Registration successful! Welcome";
            feedbackText.color = Color.green;
        }

        else if (regSuccess == false)
        {
            feedbackText.text = "Registration failed";
            feedbackText.color = Color.red;
        }

        // Display feedback text for login status
        if (loginSuccess == true)
        {
            feedbackText.text = "Login successful! Welcome back";
            feedbackText.color = Color.green;
        }

        else if (loginSuccess == false)
        {
            feedbackText.text = "Login failed";
            feedbackText.color = Color.red;
        }

        //Debug.LogWarning(regSuccess);
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
                Debug.LogWarning("Registration successful! Welcome," + newUser.Email);
                regSuccess = true;
            }
            else
            {
                Debug.LogWarning("Registration failed: " + task.Exception.GetBaseException().Message);
                regSuccess = false;
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
                loginSuccess = false;
                isLoggedIn = true;
            }
            else
            {
                Debug.LogWarning("Login failed: " + task.Exception.GetBaseException().Message /*Color.red*/);
                loginSuccess = false;
            }
        });
    }
}