using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderManager3 : MonoBehaviour
{
    public List<GameObject> gameObjs = new List<GameObject>();
    public List<GameObject> needScript = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // for each collider in list 
    }

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

    public void DisableInput()
    {
        foreach(GameObject obj in needScript)
        {
            obj.GetComponent<InputField>().interactable = false;
        }
    }
    
    public void EnableInput()
    {
        foreach(GameObject obj in needScript)
        {
            obj.GetComponent<InputField>().interactable = true;
        }
    }

}
