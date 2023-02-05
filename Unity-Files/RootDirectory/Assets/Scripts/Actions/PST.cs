using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sod-OS/InputActions/Pst")]
public class PST : InputAction
{
    public override void RespondToInput(OSController controller, string[] separatedInputWords)
    {
        controller.osNav.PasteFile(separatedInputWords);
    }
}
