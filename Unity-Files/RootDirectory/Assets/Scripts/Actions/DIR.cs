using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sod-OS/InputActions/Dir")]
public class DIR : InputAction
{
    public override void RespondToInput(OSController controller, string[] separatedInputWords)
    {
        controller.osNav.ListDirectoriesAndFiles();
    }
}
