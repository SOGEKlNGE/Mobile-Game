using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragButton : MonoBehaviour
{
    private Button dragFunctionButton;

    private void Start()
    {
        dragFunctionButton = GetComponent<Button>();
        dragFunctionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Toggle the drag input enable/disable state
        dragManager.instance.enableDragInput = !dragManager.instance.enableDragInput;
        Debug.Log("Drag Condition Met (expecting true): " + dragManager.instance.enableDragInput);

        // Log the state when drag input is disabled
        if (dragManager.instance.enableDragInput == false)
        {
            Debug.Log("Drag Condition Met (expecting false):" + dragManager.instance.enableDragInput);
        }
    }
}
