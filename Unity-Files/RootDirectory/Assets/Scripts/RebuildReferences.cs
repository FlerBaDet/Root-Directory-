using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RebuildReferences : MonoBehaviour
{
    public string StartPath = "DirectoriesSAVE";
    public Directory currentDirectory;
    public int lvl = 0;
    public OSController controller;

    private void Start()
    {
        currentDirectory = Resources.Load<Directory>(StartPath + "/root");
        StartPath = "DirectoriesSAVE";
        traverse(StartPath);
    }

    private void traverse(string path)
    {
        resetPaths(path, currentDirectory);
    }

    private void resetFiles(string path, Directory directory)
    {
        if (!directory.files.Count.Equals(0))
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

    private void resetPaths(string path, Directory directory)
    {
        //Debug.Log(path);
        if (!directory.paths.Count.Equals(0)) {
            foreach (Paths paths in directory.paths)
            {
                directory.paths.Remove(paths);
                directory.paths.Add(new Paths());
                paths.nextDirectory = Resources.Load<Directory>(path + "/" + paths.keyString + "/" + paths.keyString);
                paths.keyString = paths.nextDirectory.keyword;
                paths.nextDirectory.previousDirectory = directory;
                resetPaths(path + "/" + paths.keyString, paths.nextDirectory);
                resetFiles(path, paths.nextDirectory);
            }
        }
        else
        {
            return;
        }
        
    }

}
