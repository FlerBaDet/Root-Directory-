using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebuildReferences : MonoBehaviour
{
    public string StartPath;
    public Directory currentDirectory;
    public int lvl = 0;
    public OSController controller;

    private void Start()
    {
        currentDirectory = controller.osNav.currentDirectory;
        traverse(StartPath);
    }

    private void traverse(string path)
    {
        foreach (File file in currentDirectory.files)
        {
            currentDirectory.files.Remove(file);
        }
        File[] files = Resources.LoadAll<File>(path);
        foreach (File file in files)
        {
            currentDirectory.files.Add(file);
        }
    }

}
