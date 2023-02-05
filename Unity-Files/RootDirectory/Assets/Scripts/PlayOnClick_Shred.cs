using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnClick_Shred : MonoBehaviour
{

    public Material gradient;
    public float time;
    public float timeIncrease;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (time < 1)
        {
            time = time + timeIncrease;
            gradient.SetFloat("_TimeSet", time);
        }
        else
        {
            time = time - timeIncrease;
            gradient.SetFloat("_TimeSet", time);
        }
    }
}
