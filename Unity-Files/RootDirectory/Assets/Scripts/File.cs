using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class File : ScriptableObject
{
    [TextArea]
    public string path;
    public string keyword;
    public string type;

    public abstract void fileContents();
}
