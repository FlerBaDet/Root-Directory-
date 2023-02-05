using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sod-OS/InputActions/ADM")]
public class ADM : InputAction
{
    public override void RespondToInput(OSController controller, string[] separatedInputWords)
    {
        controller.osNav.AdminMode(separatedInputWords);
    }
}
