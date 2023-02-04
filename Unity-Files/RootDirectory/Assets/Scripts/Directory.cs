using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sod-OS/DIR")]
public class Directory : ScriptableObject
{
    [TextArea]
    public string path;
    public string keyword;
    public Directory previousDirectory;
    public File[] files;
    public Paths[] paths;
}
