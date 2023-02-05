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
    public bool deleted;

    public abstract void Open(OSController controller);
    public abstract void Delete(OSController controller);
}
