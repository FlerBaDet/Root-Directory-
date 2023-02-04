using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OSController : MonoBehaviour
{
    public Text displayText;
    public GenerateImage imageDisplay;
    public GameObject imageFolder;
    public InputAction[] inputActions;
   

    [HideInInspector] public OSNav osNav;
    [HideInInspector] public List<string> interactionDescriptionsInDirectory = new List<string>();

    [HideInInspector] public List<string> actionLog = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        if (!System.IO.Directory.Exists("Assets/Resources/DirectoriesSAVE"))
        {
            FileUtil.CopyFileOrDirectory("Assets/GameFiles/Directories", "Assets/Resources/DirectoriesSAVE");
        }
        else
        {
            
            FileUtil.DeleteFileOrDirectory("Assets/Resources/DirectoriesSAVE");
            FileUtil.CopyFileOrDirectory("Assets/GameFiles/Directories", "Assets/Resources/DirectoriesSAVE");
        }
        osNav = GetComponent<OSNav>();
        osNav.currentDirectory = Resources.Load<Directory>("DirectoriesSAVE/root");
    }

    private void Start()
    {
        DisplayDirectory();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;
        //Debug.Log("Log");
    }

    public void DisplayDirectory()
    {
        ClearCollectionsForNewDirectory();
        UnpackDirectory();

        //string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInDirectory.ToArray());

        string combinedText = osNav.currentDirectory.path + "\n";
        
        LogStringWithReturn(combinedText);
    }

    

    void UnpackDirectory()
    {
        osNav.UnpackPaths();
    }

    public void ClearCollectionsForNewDirectory()
    {
        interactionDescriptionsInDirectory.Clear();
        osNav.ClearPaths();
    }

    public void ClearImagesFromScreen()
    {
        foreach(Transform child in imageFolder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        
        imageDisplay.Translate(osNav.imageTransRate);
        actionLog.Add(stringToAdd + "\n");
        
    }

    public void LogStringWithReturn(string stringToAdd, int y)
    {
        
        imageDisplay.Translate(y);
        actionLog.Add(stringToAdd + "\n");

    }

    public void LogStringWithReturn(string stringToAdd, float loops)
    {
        imageDisplay.Translate(osNav.imageTransRate);
        for (int i = 0; i <= loops; i++)
        {
            actionLog.Add(stringToAdd + "\n");
        }
    }
    
    public void LogStringWithReturn(string stringToAdd, float loops, bool ImageLoopWith)
    {
        
        for (int i = 0; i <= loops; i++)
        {
            imageDisplay.Translate(osNav.imageTransRate);
            actionLog.Add(stringToAdd + "\n");
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
