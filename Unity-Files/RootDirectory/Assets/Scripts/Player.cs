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

    }
    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "OS")
        {
            loadOS();
        }
    }

    void loadOS()
    {
        SceneManager.LoadScene(sceneName: "OS-Creation");
    }

}
