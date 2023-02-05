using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IsMouseHovering : MonoBehaviour
{

    public Material Outline;

    private void OnMouseEnter()
    {
        Outline.SetFloat("_IsMouseHovering", 1);
    }
    private void OnMouseOver()
    {
        //Outline.SetFloat;
    }
    private void OnMouseExit()
    {
        Outline.SetFloat("_IsMouseHovering", 0);
    }
}
