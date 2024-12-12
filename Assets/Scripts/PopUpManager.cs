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
       
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        originalColor.a -= Time.deltaTime / fadeDuration;
        textComponent.color = originalColor;

      
        if (originalColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}

