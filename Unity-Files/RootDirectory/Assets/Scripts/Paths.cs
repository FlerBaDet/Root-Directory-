using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Paths
{

    public string keyString;
    public string pathDesc;
    public Directory nextDirectory;
    public Paths(string keyStringI, Directory nextDirectoryI)
    {
        keyString = keyStringI;
        nextDirectory = nextDirectoryI;
    }
    
}
