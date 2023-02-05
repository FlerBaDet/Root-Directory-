using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sod-OS/DIR")]
public class Directory : ScriptableObject
{
    
    public string admin;
    [TextArea]
    public string path;
    public string keyword;
    public Directory previousDirectory;
    public List<Paths> paths = new List<Paths>();
    public List<File> files = new List<File>();
}
