using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    float inputHorizontal;
    public float moveSpeed = 3f;
    public bool facingRight = true;
    public bool canPlayPong = false;
    public bool canLoadOS = false;

    public bool playedPong = false;

    public bool inOffice = true;
    public bool playingPong = false;
    public bool inOS = false;

    public ColliderManager colliderManager;
    public ColliderManager2 colliderManager2;
    public ColliderManager3 colliderManager3;
    public Ball ball;

    public AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal != 0)
        {
            //rb.AddForce(new Vector2(inputHorizontal * moveSpeed, 0f));
            this.transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
        }

        if (inputHorizontal > 0 && !facingRight)
        {
            flip();
        }
        else if (inputHorizontal < 0 && facingRight)
        {
            flip();
        }

        if (canPlayPong == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                unloadOffice();
                loadPong();
                canPlayPong = false;
                playingPong = true;
            }
        }
        else if (canLoadOS == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Open OS");
                unloadOffice();
                loadOS();
                canLoadOS = false;
            }
        }

        if (playingPong == true) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Escape");
                loadOffice();
                unloadPong();
                playedPong = true;
            }
        }

        if (inOS == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Escape");
                loadOffice();
                unloadOS();
            }
        }

    }

    public void disableOS()
    {
        loadOffice();
        unloadOS();
    }

    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OS")
        {
            canLoadOS = true;
        }
        else if (collision.gameObject.tag == "TV")
        {
            canPlayPong = true;
            Debug.Log("true");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TV")
        {
            canPlayPong = false;
        }
        else if(collision.gameObject.tag == "OS")
        {
            canLoadOS = false;
        }
    }


    void loadOS()
    {
        
        colliderManager3.turnOn();
        colliderManager3.EnableInput();
    }

    void unloadOS()
    {
        colliderManager3.DisableInput();
        colliderManager3.turnOff();
        
    }

    void unloadOffice()
    {
        colliderManager.unshowPlayer();
        colliderManager.turnOff();
        colliderManager.unSee();
    }

    public void loadOffice()
    {
        colliderManager.showPlayer();
        colliderManager.turnOn();
        colliderManager.See();
    }

    [System.Obsolete]
    void unloadPong()
    {
        colliderManager2.turnOff();
    }
    void loadPong()
    {
        colliderManager2.turnOn();
        if (playedPong == true)
        {
            ball.AddStartingForce();
        }
        
    }

}
