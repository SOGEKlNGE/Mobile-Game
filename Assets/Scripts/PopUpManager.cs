using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public float moveSpeed = 1f;  
    public float fadeDuration = 2f;

    private TMP_Text textComponent;
    private Color originalColor;


    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        originalColor = textComponent.color;
    }

    private void Update()
    {
        // Move the popup text upward over time
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        // Gradually reduce the alpha value of the text color for fading effect
        // Gets original color
        Color originalColor = textComponent.color;
        // Reduce alpha color
        originalColor.a -= Time.deltaTime / fadeDuration;
        // Applies new color
        textComponent.color = originalColor;

        // Destroys the popup once the text becomes fully transparent
        if (originalColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}

