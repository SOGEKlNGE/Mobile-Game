using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyroManager : MonoBehaviour
{
    public static gyroManager instance;

    public bool enableGyroInput = false;

    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
