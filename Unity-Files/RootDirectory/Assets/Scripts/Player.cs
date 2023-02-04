using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 3f;
    public bool facingRight = true;
    public bool canPlayPong = false;
    public bool canLoadOS = false;

    float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
                Debug.Log("Play Pong");
                loadPong();
            }
        }
        else if (canLoadOS == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Open OS");
                loadOS();
            }
        }

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
        SceneManager.LoadScene(1);
        canLoadOS = false;
    }

    void loadPong()
    {

        SceneManager.LoadScene(2);
        canPlayPong = false;

        //if (Input.GetKeyDown(KeyCode.E))
        //{
           // if (SceneManager.GetActiveScene().buildIndex == 0)
           // {
           //     SceneManager.LoadScene(2, LoadSceneMode.Additive);
           // }
           // else
           // {
            //    SceneManager.LoadScene(0);
            //}
        //}
    }

}
