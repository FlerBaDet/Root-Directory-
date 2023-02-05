using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sod-OS/InputActions/SHUTDOWN")]
public class SHUTDOWN : InputAction
{
    public override void RespondToInput(OSController controller, string[] separatedInputWords)
    {
        controller.osNav.ShutDown(separatedInputWords);
    }
}
