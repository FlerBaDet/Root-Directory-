using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSNav : MonoBehaviour
{
    public Directory currentDirectory;

    Dictionary<string, Directory> pathDictionary = new Dictionary<string, Directory> ();
    OSController controller;

    private void Awake()
    {
        controller = GetComponent<OSController>();
    }

    public void UnpackPaths()
    {
        for (int i = 0; i < currentDirectory.paths.Length; i++)
        {
            pathDictionary.Add(currentDirectory.paths[i].keyString, currentDirectory.paths[i].nextDirectory);
            controller.interactionDescriptionsInDirectory.Add(currentDirectory.paths[i].pathDesc);
        }
    }

    public void AttemptToChangeDirectories(string directoryName)
    {
        if (pathDictionary.ContainsKey(directoryName))
        {
            currentDirectory = pathDictionary[directoryName];
            controller.LogStringWithReturn(currentDirectory.path + "/" + directoryName);
            controller.DisplayDirectory();
        }
        else
        {
            controller.LogStringWithReturn("Directory '" + directoryName + "' does not exist");
        }
    }

    public void ClearPaths()
    {
        pathDictionary.Clear();
    }

}
