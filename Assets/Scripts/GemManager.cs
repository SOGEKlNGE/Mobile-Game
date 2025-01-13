using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GemManager : MonoBehaviour
{
    [SerializeField] private Text gemText;
    [SerializeField] public int gems = 0;
    public static int totalGems = 0;

    private void Awake()
    {
        //PlayerPrefs.DeleteKey("Gems");
    }

    private void Start()
    {
        gems = PlayerPrefs.GetInt("Gems", 0);
        UpdateGemUI();
    }

    public void UpdateGemUI()
    {
        gemText.text = gems.ToString();
        PlayerPrefs.SetInt("Gems", gems);
    }
}
