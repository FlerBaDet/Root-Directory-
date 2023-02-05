using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.Windows;

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
            for (int i = 0; i < directory.paths.Count; i++)
            {
                Paths oldPath = directory.paths[i];
                directory.paths.RemoveAt(i);

                //Resources.Load<File>(path + "/" + oldPath.keyString + "/" + oldPath.keyString).Move(oldPath.keyString, oldPath.keyString + ",");
                Directory nextDirectory = Resources.Load<Directory>(path + "/" + oldPath.keyString + "/" + oldPath.keyString);
                string key = nextDirectory.keyword;
                Paths newPath = new Paths(key, nextDirectory);
                directory.paths.Add(newPath);
                

                newPath.nextDirectory.previousDirectory = directory;

                resetPaths(path + "/" + newPath.keyString, newPath.nextDirectory);
                resetFiles(path + "/" + newPath.keyString, newPath.nextDirectory);
            }
        }
        else
        {
            return;
        }
        
    }

}
