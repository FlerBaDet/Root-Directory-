using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sod-OS/InputActions/OPEN")]
public class OPEN : InputAction
{
    public override void RespondToInput(OSController controller, string[] separatedInputWords)
    {
        controller.osNav.DisplayFile(separatedInputWords);
    }
}
