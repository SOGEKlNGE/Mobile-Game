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

        // get screen bounds in world coordinates
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // calculate half the object's width and height
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        // clamp x position with screen bounds
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);

        // define y-axis boundaries
        float bottomBoundary = screenBounds.y * -1 + objectHeight; 
        float topBoundary = customTopBoundary - objectHeight; 

        // clamp y within defined boundaries.
        // set so the top of the table is the boundary.
        viewPos.y = Mathf.Clamp(viewPos.y, bottomBoundary, topBoundary);

        transform.position = viewPos;
    }
}

// References:
// Start, P (2018) Unity - Keeping The Player Within Screen Boundaries [online] Available at: https://www.youtube.com/watch?v=ailbszpt_AI [Accessed 20 Oct 2024]
