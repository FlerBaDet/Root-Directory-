using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using UnityEngine;

public class OSNav : MonoBehaviour
{
    public Directory currentDirectory;
    public Directory root;
    public File copiedFile;
    public int imageMoveRate = 7;
    public int imageTransRate = 14;
    public int imageFollowRate = 38;
    bool deleteSucc = false;
    bool openSucc = false;
    bool copySucc = false;
    bool pasteFail = false;

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

        pathDictionary.Add(currentDirectory.previousDirectory.keyword, currentDirectory.previousDirectory);
        pathDictionary.Add(root.keyword, root);
    }

    public void AttemptToChangeDirectories(string directoryName) //CD
    {
        if (directoryName == currentDirectory.previousDirectory.keyword | pathDictionary.ContainsKey(directoryName))
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
                if (!file.deleted)
                {
                    controller.LogStringWithReturn(file.keyword);
                }
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
                if (file.keyword.ToLower() == separatedInputWords[1].ToLower() && !file.deleted)
                {
                    //currentDirectory.files.Remove(file);
                    file.deleted = true;
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

    public void CopyFile(string[] separatedInputWords)
    {
        if (currentDirectory.files.Count > 0)
        {
            foreach (File file in currentDirectory.files)
            {
                if (file.keyword.ToLower() == separatedInputWords[1].ToLower() && !file.deleted)
                {
                    //currentDirectory.files.Remove(file);
                    copiedFile = Instantiate(file);
                    controller.LogStringWithReturn("Copied File: " + separatedInputWords[1]);
                    copySucc = true;
                    break;
                }
            }
        }
        if (!copySucc)
        {
            controller.LogStringWithReturn("File '" + separatedInputWords[1] + "' was not found");
        }
        else
        {
            copySucc = false;
        }

        controller.LogStringWithReturn("============================");
        controller.DisplayDirectory();
    }

    public void PasteFile(string[] separatedInputWords)
    {
        foreach (File file in currentDirectory.files)
        {
            if (file.keyword.ToLower() == separatedInputWords[1].ToLower() && !file.deleted)
            {
                controller.LogStringWithReturn(separatedInputWords[1] + " already exists here");
                pasteFail = true;
                break;
            }
        }
        
        if (!pasteFail)
        {
            
            currentDirectory.files.Add(copiedFile);
            controller.LogStringWithReturn("Pasted File: " + separatedInputWords[1]);
        }
        else
        {
            pasteFail = false;
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
