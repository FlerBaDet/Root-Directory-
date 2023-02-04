using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Sod-OS/InputActions/Go")]
public class CD : InputAction
{
    public override void RespondToInput(OSController controller, string[] separatedInputWords)
    {
        //Debug.Log(separatedInputWords[1]);
        controller.osNav.AttemptToChangeDirectories(separatedInputWords[1]);
    }
}
