using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{

    public List<GameObject> gameObjs = new List<GameObject>();
    public List<GameObject> needScript = new List<GameObject>();
    public GameObject player;
    public GameObject animation;

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

    public void unSee()
    {
        foreach (GameObject obj in needScript)
        {
            obj.GetComponent<Collider2D>().enabled = false;
            obj.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void See()
    {
        foreach (GameObject obj in needScript)
        {
            obj.GetComponent<Collider2D>().enabled = true;
            obj.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void showPlayer()
    {
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<CircleCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void unshowPlayer()
    {
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void showAnimation()
    {
        animation.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void unshowAnimation()
    {
        animation.GetComponent<SpriteRenderer>().enabled = false;
    }

}
