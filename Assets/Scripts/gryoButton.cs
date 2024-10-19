using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gryoButton : MonoBehaviour
{
    private Button gyroButton;

    private void Start()
    {
        gyroButton = GetComponent<Button>();
        gyroButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        gyroManager.instance.enableGyroInput = !gyroManager.instance.enableGyroInput;
        Debug.Log("Condition Met: " + gyroManager.instance.enableGyroInput);
    }
}
