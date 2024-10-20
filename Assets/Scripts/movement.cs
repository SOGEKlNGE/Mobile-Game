using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private void Start()
    {
      

        if (gyroManager.instance != null && gyroManager.instance.enableGyroInput)
        {
            Input.gyro.enabled = true; 
            Debug.Log("Movement gyro scope something happened");
            rightButton.gameObject.SetActive(false);
            leftButton.gameObject.SetActive(false);
            downButton.gameObject.SetActive(false);
            upButton.gameObject.SetActive(false);
        }
        else if (dragManager.instance != null && dragManager.instance.enableDragInput)
        {
            Debug.Log("Movement Drag something happened");
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
            Debug.Log("UPDATE MOVEMENT gyro scope something happened");
        }
    }

    private void GyroControl()
    {
        Vector3 gyroInput = Input.gyro.rotationRate;
        smoothGyroInput = Vector3.Lerp(smoothGyroInput, gyroInput, gyroSmooth);
        transform.position += new Vector3(smoothGyroInput.x, smoothGyroInput.y, 0) * gyroSensitivity;
    }


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
            Destroy(other.gameObject);
        }
    }


}


