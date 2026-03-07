using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uptick : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 5;
    public string nextLevel = "brrskibidi 2";
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    string thislevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thislevel);
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }


        }

    }
    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            sr.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sr.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sr.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sr.color = Color.blue;
        }
        /*
                if (Input.GetKeyDown(KeyCode.W))
                {
                    transform.position+= new Vector3(0,1,0);
                    }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.position-=new Vector3(1,0,0);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    transform.position -= new Vector3(0,1,0);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.position += new Vector3(1,0,0);
                }
        */

    }
}
