using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyroManager : MonoBehaviour
{
    public static gyroManager instance;

    public bool enableGyroInput = false;

    private void Awake()
    {
        // sets this as instance if no instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            // if instance exists, destroys duplicate
            Destroy(gameObject); 
        }
    }
}
