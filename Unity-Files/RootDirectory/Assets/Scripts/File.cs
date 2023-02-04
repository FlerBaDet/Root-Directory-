using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Sod-OS/FILE")]
public class File : ScriptableObject
{
    [TextArea]
    public string path;
    public string keyword;
    public string type;
}
