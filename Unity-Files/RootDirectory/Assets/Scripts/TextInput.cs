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
        //Debug.Log(userInput);
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);

        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyWord.ToLower() == separatedInputWords[0])//CD
            {
                //Debug.Log(separatedInputWords[0]);
                inputAction.RespondToInput(controller, separatedInputWords);
            }
        }

        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }

}
