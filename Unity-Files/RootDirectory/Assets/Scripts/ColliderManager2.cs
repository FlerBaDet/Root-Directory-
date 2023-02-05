using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager2 : MonoBehaviour
{
    public List<GameObject> gameObjs = new List<GameObject>();

    public void turnOff()
    {
        foreach (GameObject obj in gameObjs)
        {
            obj.SetActive(false);
        }
    }

    public void turnOn()
    {
        foreach (GameObject obj in gameObjs)
        {
            obj.SetActive(true);
        }
    }

}
