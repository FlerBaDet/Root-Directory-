using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCloud : MonoBehaviour
{
    float timer = 0;
    float moveDistX;
    Vector3 moveDist;
    // Start is called before the first frame update
    void Start()
    {
        moveDistX = GetComponent<Renderer>().bounds.size.x / 7;

        moveDist = new Vector3(moveDistX, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        
        if(timer > 0.4)
        {
            transform.Translate(moveDist);
            timer = 0;
        }
    }
}
