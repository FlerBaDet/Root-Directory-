using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSNav : MonoBehaviour
{
    public Directory currentDirectory;

    OSController controller;

    private void Awake()
    {
        controller = GetComponent<OSController>();
    }

    public void UnpackPaths()
    {
        for (int i = 0; i < currentDirectory.paths.Length; i++)
        {
            controller.interactionDescriptionsInDirectory.Add(currentDirectory.paths[i].pathDesc);
        }
    }

}
