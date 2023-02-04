using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSNav : MonoBehaviour
{
    public Directory currentDirectory;
    public int imageMoveRate = 7;
    public int imageTransRate = 38;

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
            //controller.LogStringWithReturn(currentDirectory.path);
            controller.DisplayDirectory();
        }
        else
        {
            controller.LogStringWithReturn("Directory '" + directoryName + "' does not exist" + "\n");
        }
    }

    public void ListDirectoriesAndFiles()
    {
        for (int i = 0; i < currentDirectory.paths.Length; i++)
        {
            controller.LogStringWithReturn(currentDirectory.paths[i].keyString);
        }
        for (int i = 0; i < currentDirectory.files.Length; i++)
        {
            controller.LogStringWithReturn(currentDirectory.files[i].keyword);
        }
        //controller.LogStringWithReturn("");
        controller.DisplayDirectory();
        
    }

    public void DisplayFile(string[] separatedInputWords)
    {
        foreach(File file in currentDirectory.files)
        {
            if (file.keyword.ToLower() == separatedInputWords[1].ToLower())
            {
                file.Open(controller);
                if (file.type == "jpog")
                {
                    controller.LogStringWithReturn("");
                }
            }
        }
        controller.DisplayDirectory();
    }

    public void ClearScreen()
    {
        ClearPaths();

        controller.displayText.text = null;
        //Delete all the images
    }


    public void ClearPaths()
    {
        pathDictionary.Clear();
    }

}
