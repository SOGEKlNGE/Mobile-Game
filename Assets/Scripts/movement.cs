using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float move = 1f;

    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

    private void Start()
    {
        upButton.onClick.AddListener(MoveUp);
        downButton.onClick.AddListener(MoveDown);
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
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

}


