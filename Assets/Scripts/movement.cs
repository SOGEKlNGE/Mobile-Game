using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CandyCoded;
using CandyCoded.HapticFeedback;

public class movement : MonoBehaviour
{
    public float move = 2f;

    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

    private Vector3 smoothGyroInput;  
    public float gyroSensitivity = 0.5f;  
    public float gyroSmooth = 0.1f;

    private Vector3 dragOffset;
    private Camera mainCamera;

    public Text scoreText;
    public float score = 0;

    public GameObject popUpPrefab;
    
    public AudioClip collisionSFX;
    public AudioSource audioSource;

    private void Awake()
    {
        
    }

    private void Start()
    {

        mainCamera = Camera.main;

        // if gyro input is enabled via the main menu settings then the movement will be as such. (buttons will be hidden from screen).
        if (gyroManager.instance != null && gyroManager.instance.enableGyroInput)
        {
            Input.gyro.enabled = true; 
            Debug.Log("Movement gyro scope something happened");
            rightButton.gameObject.SetActive(false);
            leftButton.gameObject.SetActive(false);
            downButton.gameObject.SetActive(false);
            upButton.gameObject.SetActive(false);
        }

        // similar to above code
        else if (dragManager.instance != null && dragManager.instance.enableDragInput)
        {
            Debug.Log("Movement Drag");
        }
        else
        {
            upButton.onClick.AddListener(MoveUp);
            downButton.onClick.AddListener(MoveDown);
            leftButton.onClick.AddListener(MoveLeft);
            rightButton.onClick.AddListener(MoveRight);
        }
    }

    public void Update()
    {

        if (gyroManager.instance != null && gyroManager.instance.enableGyroInput)
        {
            GyroControl();
            Debug.Log("UPDATE MOVEMENT Gyro input");
        }

        else if (dragManager.instance.enableDragInput)
        {
            HandleDrag();
            Debug.Log("UPDATE MOVEMENT Drag input");
        }

    }

    private void GyroControl()
    {
        Vector3 gyroInput = Input.gyro.rotationRate;
        // linear interpolation for smooth gyro input
        smoothGyroInput = Vector3.Lerp(smoothGyroInput, gyroInput, gyroSmooth);
        // adjust objects position based on chosen sensitivity and smooth gyro.
        transform.position += new Vector3(smoothGyroInput.x, smoothGyroInput.y, 0) * gyroSensitivity;
    }

    private void HandleDrag()
    {
        // checks if atleast one touch
        if (Input.touchCount > 0)
        {
            // gets first input touch
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    // calculate the offset between object position and touch position
                    Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                    dragOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y));
                    break;

                case TouchPhase.Moved:

                    // update object position based on touch movement and offset
                    Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y)) + dragOffset;

                    // keep movement 2D.
                    newPosition.z = 0;
                    transform.position = newPosition;
                    break;
            }
        }
    }
    
    // default movement controls
    public void MoveUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + move);
    }

    public void MoveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - move);
    }

    public void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - move, transform.position.y);
    }

    public void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + move, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {

            Debug.Log("Collision with Food");
            HapticFeedback.LightFeedback();
            Destroy(other.gameObject);

            PointPopUp("+1", Color.green);
            audioSource.PlayOneShot(collisionSFX);

            score++;
            scoreText.text = score.ToString();
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with Obstacle");
            HapticFeedback.HeavyFeedback();

            Destroy(other.gameObject);

            PointPopUp("-5", Color.red);

            score = score - 5;
            scoreText.text = score.ToString();
        }

        if (score <= 0)
        {
            score = 0;
            scoreText.text = score.ToString();
        }
    }

    public void PointPopUp(string text, Color color)
    {
        GameObject popup = Instantiate(popUpPrefab, transform.position + Vector3.up, Quaternion.identity);

        Vector3 popupPosition = new Vector3(transform.position.x, transform.position.y + 2, -2);
        popup.transform.position = popupPosition;

        TMP_Text popupText = popup.GetComponentInChildren<TMP_Text>();
        popupText.text = text;
        popupText.color = color;
        Destroy(popup, 2f);
    }

}

// Reference:
// Leonardo, D (2021) Drag and Drop for Mobile & Desktop in Unity [online] Available at: https://www.youtube.com/watch?v=FdxvTcHJiA8 [Accessed 20 Oct 2024]
// Zotov, A (2018) Unity3D Android Gyroscope Controls (with a helicopter game) [online] Available at: https://www.youtube.com/watch?v=wpSm2O2LIRM [Accessed 20 Oct 2024]
// LearnWithYas (2024) How to move a 3D object using touch input ( x and y-axis ONLY ) - Unity Mobile [online] Available at: https://www.youtube.com/watch?v=YDSkiQDvYv8 [Accessed 20 Oct 2024]
