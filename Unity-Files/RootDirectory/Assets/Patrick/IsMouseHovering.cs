using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IsMouseHovering : MonoBehaviour
{


    private void OnMouseEnter()
    {
        Shader.SetGlobalFloat("_IsMouseHovering", 1);
        Debug.Log("Mouse enter");
    }
    private void OnMouseOver()
    {
        Shader.SetGlobalFloat("_IsMouseHovering", 1);
        Debug.Log("Mouse hover");
    }
    private void OnMouseExit()
    {
        Shader.SetGlobalFloat("_IsMouseHovering", 0);
        Debug.Log("Mouse exit");
    }
}
