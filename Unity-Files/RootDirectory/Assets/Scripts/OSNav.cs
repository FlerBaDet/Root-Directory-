using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using UnityEngine;

public class OSNav : MonoBehaviour
{
    public Directory currentDirectory;
    public int imageMoveRate = 7;
    public int imageTransRate = 14;
    public int imageFollowRate = 38;
    bool deleteSucc = false;
    bool openSucc = false;

    Dictionary<string, Directory> pathDictionary = new Dictionary<string, Directory> ();
    OSController controller;

    private void Awake()
    {
        controller = GetComponent<OSController>();
        //currentDirectory = Resources.Load("Assets/GameFiles/DirectoriesSAVE/root") as Directory;
    }

    private void Start()
    {
        //currentDirectory = Resources.Load("Assets/GameFiles/DirectoriesSAVE/root") as Directory;
        
    }

    public void UnpackPaths()
    {
        if (currentDirectory.paths.Count > 0)
        {
            foreach (Paths path in currentDirectory.paths)
            {
                pathDictionary.Add(path.keyString, path.nextDirectory);
                controller.interactionDescriptionsInDirectory.Add(path.pathDesc);
            }
        }
    }

    public void AttemptToChangeDirectories(string directoryName) //CD
    {
        if (pathDictionary.ContainsKey(directoryName))
        {
            currentDirectory = pathDictionary[directoryName];
            controller.LogStringWithReturn("============================");
            controller.DisplayDirectory();
        }
        else
        {
            controller.LogStringWithReturn("Directory '" + directoryName + "' does not exist" + "\n");
        }
    }

    public void ListDirectoriesAndFiles() //DIR
    {
        if (currentDirectory.paths.Count > 0)
        {
            foreach (Paths path in currentDirectory.paths)
            {
                controller.LogStringWithReturn(path.keyString);
            }
        }
        if (currentDirectory.files.Count > 0)
        {
            foreach (File file in currentDirectory.files)
            {
                controller.LogStringWithReturn(file.keyword);
            }
        }
        controller.LogStringWithReturn("============================");
        controller.DisplayDirectory();
        
    }

    public void DisplayFile(string[] separatedInputWords) //OPEN
    {
        if (currentDirectory.files.Count > 0)
        {
            foreach (File file in currentDirectory.files)
            {
                if (file.keyword.ToLower() == separatedInputWords[1].ToLower())
                {
                    file.Open(controller);
                    openSucc = true;
                }
            }
        }
        if (!openSucc)
        {
            controller.LogStringWithReturn("File '" + separatedInputWords[1] + "' was not found");
        }
        else
        {
            openSucc = false;
        }
        controller.LogStringWithReturn("============================");
        controller.DisplayDirectory();
    }

    public void DeleteFile(string[] separatedInputWords)
    {
        if (currentDirectory.files.Count > 0)
        {
            foreach (File file in currentDirectory.files)
            {
                if (file.keyword.ToLower() == separatedInputWords[1].ToLower())
                {
                    currentDirectory.files.Remove(file);
                    controller.LogStringWithReturn("Deleted File: " + separatedInputWords[1]);
                    deleteSucc = true;
                    break;
                }
            }
        }
        if (!deleteSucc)
        {
            controller.LogStringWithReturn("File '" + separatedInputWords[1] + "' was not found");
        }
        else
        {
            deleteSucc = false;
        }

        controller.LogStringWithReturn("============================");
        controller.DisplayDirectory();
    }


    public void ClearScreen() //CLS
    {
        ClearPaths();
        controller.ClearCollectionsForNewDirectory();
        controller.actionLog.Clear();
        controller.displayText.text.Remove(0);
        controller.ClearImagesFromScreen();

        controller.DisplayDirectory();

    }




    public void ClearPaths()
    {
        pathDictionary.Clear();
    }

}
