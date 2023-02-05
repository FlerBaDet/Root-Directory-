using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class LampSwitch : MonoBehaviour
{

    public Material Outline;
    public string name;
    AudioSource m_AudioSource;
    bool m_switch;
    

    private void Start()
    {
       
      

    }
    private void OnMouseEnter()
    {
        Outline.SetFloat("_LampSwitch", 1);
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
           

            if (m_switch == false)
            {
                m_switch = true;
            }
            else
            {
                m_switch = false;
            }
        }

        if (m_switch == true)
        {
            moveLampBack();
        }
        else if (m_switch == false)
        {
            moveLampForward();
        }
        //Outline.SetFloat;
    }

    private void moveLampBack()
    {
        transform.position = new Vector3(2.34f, -0.86f, 1.0f);
    }

    private void moveLampForward()
    {
        transform.position = new Vector3(2.34f, -0.86f, -0.11f);
    }

    private void OnMouseExit()
    {
        Outline.SetFloat("_IsMouseHovering", 0);
    }
}
