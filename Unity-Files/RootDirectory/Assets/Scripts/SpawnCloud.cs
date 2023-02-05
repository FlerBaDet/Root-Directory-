using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{

    float timer = 0;
    bool spawnedCloud = false;
    int cloudNum;

    public int spawnTime = 5;

    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public GameObject cloud4; 
    public GameObject cloud5;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(-3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if(timer > spawnTime)
        {

            cloudNum = Random.Range(1, 5);

            if(cloudNum == 1)
            {
                GameObject newObject = Instantiate(cloud1);
            }

            if (cloudNum == 2)
            {
                GameObject newObject = Instantiate(cloud2);
            }

            if (cloudNum == 3)
            {
                GameObject newObject = Instantiate(cloud3);
            }

            if (cloudNum == 4)
            {
                GameObject newObject = Instantiate(cloud4);
            }

            if (cloudNum == 5)
            {
                GameObject newObject = Instantiate(cloud5);
            }

            //spawn cloud

            timer = Random.Range(-2, 1);
        }



    }
}
