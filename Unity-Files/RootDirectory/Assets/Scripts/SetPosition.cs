using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SetPosition : MonoBehaviour
{
    public Transform position;
    public Transform relativeTo;
    private void Awake()
    {
        gameObject.transform.position = relativeTo.position;
    }
}
