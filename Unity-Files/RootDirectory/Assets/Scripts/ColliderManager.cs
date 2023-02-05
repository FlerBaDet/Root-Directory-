using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{

    public List<GameObject> collider2Ds = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // for each collider in list 
    }

    public void Dable()
    {
        foreach(GameObject obj in collider2Ds)
        {
            //obj. = false;
        }
    }

}
