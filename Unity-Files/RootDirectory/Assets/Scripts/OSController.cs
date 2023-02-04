using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OSController : MonoBehaviour
{
    public Text displayText;
    public GenerateImage imageDisplay;
    public InputAction[] inputActions;

    [HideInInspector] public OSNav osNav;
    [HideInInspector] public List<string> interactionDescriptionsInDirectory = new List<string>();

    List<string> actionLog = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        osNav = GetComponent<OSNav>();
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
        //Debug.Log("Display: " + logAsText);
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

    void ClearCollectionsForNewDirectory()
    {
        interactionDescriptionsInDirectory.Clear();
        osNav.ClearPaths();
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




    // Update is called once per frame
    void Update()
    {
        
    }
}
