using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EVENT : ScriptableObject
{
    
    public string author;
    public string date;
    [TextArea]
    public string message;
    public int lineBreaks;
    public int eventNumber;
    public string command;
    public Directory location;
    public File file;
    public bool completed;

    public abstract void Load(OSController controller);

}
