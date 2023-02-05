using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IsMouseHovering : MonoBehaviour
{

    public Material Outline;
    public string name;
    AudioSource m_AudioSource;
    Animation m_animation;
    Animator m_animator;
    bool m_Play;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_animation = GetComponent<Animation>();
        m_animator = GetComponent<Animator>();

    }
    private void OnMouseEnter()
    {
        Outline.SetFloat("_IsMouseHovering", 1);
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_AudioSource.Play();
            m_animator.SetTrigger("Active");
        }
        //Outline.SetFloat;
    }
    private void OnMouseExit()
    {
        Outline.SetFloat("_IsMouseHovering", 0);
    }
}


