using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    public float customTopBoundary = 0f;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);

        // Y-axis boundaries
        float bottomBoundary = screenBounds.y * -1 + objectHeight; 
        float topBoundary = customTopBoundary - objectHeight; 


        viewPos.y = Mathf.Clamp(viewPos.y, bottomBoundary, topBoundary);

        transform.position = viewPos;
    }
}

// https://www.youtube.com/watch?v=ailbszpt_AI