using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragManager : MonoBehaviour
{
    // Static instance for singleton pattern
    public static dragManager instance;

    // Boolean to control the drag input state
    public bool enableDragInput = false;

    private void Awake()
    {
        //Ensure only one instance of dragManager exists
        if (instance == null)
        {
            instance = this;
            // Keep the instance across scene loads
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            // Destroy duplicate instances
            Destroy(gameObject);
        }
    }
}
