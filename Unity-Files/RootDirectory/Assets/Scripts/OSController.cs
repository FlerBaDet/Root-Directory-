using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OSController : MonoBehaviour
{
    public Text displayText;

    [HideInInspector] public OSNav osNav;

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
    }

    public void DisplayDirectory()
    {
        string combinedText = osNav.currentDirectory.path + "\n";

        LogStringWithReturn(combinedText);
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
