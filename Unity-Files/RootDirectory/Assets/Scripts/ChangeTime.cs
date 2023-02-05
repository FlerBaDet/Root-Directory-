using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{


    public float time = 0;
    public float timeIncrease = 0.01f;
    public bool goingUp = true;

    public Material gradient;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 1 && goingUp == true)
        {
            goingUp = false;
        }

        if (time < 0 && goingUp == false)
        {
            goingUp=true;
        }

        if (goingUp == true)
        {
            time = time + timeIncrease;
            gradient.SetFloat("_TimeSet", time);
        }
        
  

        if (goingUp == false)
        {
            time = time - timeIncrease;
            gradient.SetFloat("_TimeSet", time);
        }
    }
}
