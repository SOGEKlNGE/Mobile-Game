using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GemManager : MonoBehaviour
{
    [SerializeField] private Text gemText;
    [SerializeField] public int gems = 0;
    private void Start()
    {

    }

    public void UpdateGemUI()
    {
        gems = gems + 10;
        gemText.text = "" + gems;
    }
}
