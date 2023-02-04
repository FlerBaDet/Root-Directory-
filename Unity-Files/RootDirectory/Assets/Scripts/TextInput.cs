using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;

    OSController controller;

    void Awake()
    {
        controller = GetComponent<OSController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
        inputField.caretWidth = 120;
    }


    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);
        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }

}
