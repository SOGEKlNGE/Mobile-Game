using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragManager : MonoBehaviour
{
    public static dragManager instance;

    public bool enableDragInput = false;

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
