using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GemManager : MonoBehaviour
{
    // Store and modify gem amount
    [SerializeField] private Text gemText;
    [SerializeField] public int gems = 0;
    public static int totalGems = 0;

    private void Awake()
    {
        //PlayerPrefs.DeleteKey("Gems");
    }

    private void Start()
    {
        // Retrieves the stored gem count from PlayerPrefs - default is 0, if not found
        gems = PlayerPrefs.GetInt("Gems", 0);
        UpdateGemUI();
    }

    public void UpdateGemUI()
    {
        // Updates the gem display on screen
        gemText.text = gems.ToString();

        // Saves the current gem count in PlayerPrefs for persistence
        PlayerPrefs.SetInt("Gems", gems);
    }
}
