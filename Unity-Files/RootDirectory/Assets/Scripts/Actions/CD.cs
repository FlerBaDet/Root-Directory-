using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SodOS/InputActions/Go")]
public class CD : InputAction
{
    public override void RespondToInput(OSController controller, string[] seperatedInputWords)
    {
        controller.osNav.AttemptToChangeDirectories(seperatedInputWords[1]);
    }
}
