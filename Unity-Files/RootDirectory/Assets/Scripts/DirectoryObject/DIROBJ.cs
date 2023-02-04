using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIROBJ : MonoBehaviour
{
    public Directory directory;
    // Start is called before the first frame update
    void Start()
    {
        directory = Instantiate(directory);
    }

}
