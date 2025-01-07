using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GemManager : MonoBehaviour
{
    [SerializeField] private Text gemText;

    private void Start()
    {
        UpdateGemUI();
    }

    public void UpdateGemUI()
    {
        int gems = PlayerPrefs.GetInt("Gems", 0);
        gemText.text = "Gems: " + gems;
    }
}
