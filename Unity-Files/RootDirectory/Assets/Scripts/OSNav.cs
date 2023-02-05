using JetBrains.Annotations;
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
    public bool isAdmin = false;
    public int imageMoveRate = 7;
    public int imageTransRate = 14;
    public int imageFollowRate = 38;
    public string divider = "=========================================================";
    bool deleteSucc = false;
    bool openSucc = false;
    bool copySucc = false;
    bool pasteFail = false;
    bool cutSucc = false;

    Dictionary<string, Directory> pathDictionary = new Dictionary<string, Directory> ();
    OSController controller;
    EventManager EM;

    private void Awake()
    {
        controller = GetComponent<OSController>();
        EM = GetComponent<EventManager>();
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
                if (path != null)
                {
                    pathDictionary.Add(path.keyString, path.nextDirectory);
                    controller.interactionDescriptionsInDirectory.Add(path.pathDesc);
                }
            }
            
        }

        pathDictionary.Add(currentDirectory.previousDirectory.keyword, currentDirectory.previousDirectory);
        if (currentDirectory != root && !pathDictionary.ContainsValue(root))
        {
            pathDictionary.Add(root.keyword, root);
        }
    }

    public void AttemptToChangeDirectories(string directoryName) //CD
    {
        if (directoryName.ToLower() == currentDirectory.previousDirectory.keyword.ToLower() | pathDictionary.ContainsKey(directoryName))
        {
            if (pathDictionary[directoryName].admin != "t" || isAdmin)
            {
                currentDirectory = pathDictionary[directoryName];
                controller.LogStringWithReturn(divider);
                controller.DisplayDirectory();
            }
            else
            {
                controller.LogStringWithReturn(directoryName + " HAS ADMIN ONLY ACESS");
                controller.LogStringWithReturn(divider);
            }
        }
        else
        {
            controller.LogStringWithReturn("Directory '" + directoryName + "' does not exist");
            controller.LogStringWithReturn(divider);
        }
    }

    public void ListDirectoriesAndFiles() //DIR
    {
        if (currentDirectory.paths.Count > 0)
        {
            foreach (Paths path in currentDirectory.paths)
            {
                if (path != null)
                {
                    if (path.nextDirectory.admin != "t" || isAdmin)
                    {
                        controller.LogStringWithReturn(path.keyString);
                    }
                }
            }
        }
        if (currentDirectory.files.Count > 0)
        {
            foreach (File file in currentDirectory.files)
            {
                if (file != null)
                {
                    if (!file.deleted)
                    {
                        controller.LogStringWithReturn(file.keyword);
                    }
                }
            }
        }
        controller.LogStringWithReturn(divider);
        controller.DisplayDirectory();
        
    }

    public void DisplayFile(string[] separatedInputWords) //OPEN
    {
        if (currentDirectory.files.Count > 0)
        {
            foreach (File file in currentDirectory.files)
            {
                if (file != null)
                {
                    if (file.keyword.ToLower() == separatedInputWords[1].ToLower())
                    {
                        if (file.type == "jpog" || file.type == "txt")
                        {
                            file.Open(controller);
                        }
                        else if (file.type == "exe")
                        {
                            file.Open(controller, EM);
                        }
                        openSucc = true;
                    }
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
        controller.LogStringWithReturn(divider);
        controller.DisplayDirectory();
    }

    public void DeleteFile(string[] separatedInputWords) //DEL
    {
        if (currentDirectory.files.Count > 0)
        {
            foreach (File file in currentDirectory.files)
            {
                if (file != null)
                {
                    if (file.keyword.ToLower() == separatedInputWords[1].ToLower() && !file.deleted)
                    {
                        EM.EventCheck(controller, separatedInputWords[0], file);
                        file.deleted = true;
                        controller.LogStringWithReturn("Deleted File: " + separatedInputWords[1]);
                        deleteSucc = true;
                        break;
                    }
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

        controller.LogStringWithReturn(divider);
        controller.DisplayDirectory();
    }

    public void CopyFile(string[] separatedInputWords)
    {
        if (currentDirectory.files.Count > 0)
        {
            foreach (File file in currentDirectory.files)
            {
                if (file != null)
                {
                    if (file.keyword.ToLower() == separatedInputWords[1].ToLower() && !file.deleted)
                    {
                        EM.EventCheck(controller, separatedInputWords[0], file);
                        copiedFile = Instantiate(file);
                        controller.LogStringWithReturn("Copied File: " + separatedInputWords[1]);
                        copySucc = true;
                        break;
                    }
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

        controller.LogStringWithReturn(divider);
        controller.DisplayDirectory();
    }

    public void PasteFile(string[] separatedInputWords)
    {
        foreach (File file in currentDirectory.files)
        {
            if (file != null)
            {
                if (file.keyword.ToLower() == separatedInputWords[1].ToLower() && !file.deleted)
                {
                    controller.LogStringWithReturn(separatedInputWords[1] + " already exists here");
                    pasteFail = true;
                    break;
                }
            }
        }
        
        if (!pasteFail)
        {
            EM.EventCheck(controller, separatedInputWords[0], copiedFile);
            currentDirectory.files.Add(copiedFile);
            controller.LogStringWithReturn("Pasted File: " + separatedInputWords[1]);
        }
        else
        {
            pasteFail = false;
        }

        controller.LogStringWithReturn(divider);
        controller.DisplayDirectory();
    }

    public void CutFile(string[] separatedInputWords)
    {
        if (currentDirectory.files.Count > 0)
        {
            foreach (File file in currentDirectory.files)
            {
                if (file != null)
                {
                    if (file.keyword.ToLower() == separatedInputWords[1].ToLower() && !file.deleted)
                    {
                        EM.EventCheck(controller, separatedInputWords[0], file);
                        copiedFile = Instantiate(file);
                        //controller.LogStringWithReturn("Copied File: " + separatedInputWords[1]);
                        cutSucc = true;
                        break;
                    }
                }
            }
        }
        if (!cutSucc)
        {
            controller.LogStringWithReturn("File '" + separatedInputWords[1] + "' was not found");
        }
        else
        {
            if (currentDirectory.files.Count > 0)
            {
                foreach (File file in currentDirectory.files)
                {
                    if (file != null)
                    {
                        if (file.keyword.ToLower() == separatedInputWords[1].ToLower() && !file.deleted)
                        {
                            EM.EventCheck(controller, separatedInputWords[0], file);
                            file.deleted = true;
                            controller.LogStringWithReturn("Cut File: " + separatedInputWords[1]);
                            break;
                        }
                    }
                }
            }
            cutSucc = false;
        }

        

        controller.LogStringWithReturn(divider);
        controller.DisplayDirectory();
    }

    public void AdminMode(string[] separetedInputWords)
    {
        if (separetedInputWords[1].ToLower() == "hotstuff68")
        {
            isAdmin = true;
            controller.LogStringWithReturn("SUCCESS: NOW LOGGED IN AS ADMIN");
            controller.LogStringWithReturn(divider);
        }
        else
        {
            controller.LogStringWithReturn("INCORRECT PASSWORD");
            controller.LogStringWithReturn(divider);
        }
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
