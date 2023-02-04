using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    public string keyWord;
    public abstract void RespondToInput (OSController controller, string[] seperatedInputWords);
}
