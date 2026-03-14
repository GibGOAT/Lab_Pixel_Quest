using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uptick : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 4;
    public string nextLevel = "Level2";
    private SpriteRenderer sr;

    private float xInput;
    private float yInput;

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case "Finish":
                SceneManager.LoadScene(nextLevel);
                break;
        }
    }

    void Update()
    {
        // Read player input
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical"); // optional for buoyancy-assisted movement

        // Color changing
        if (Input.GetKeyDown(KeyCode.Alpha0)) sr.color = Color.white;
        if (Input.GetKeyDown(KeyCode.Alpha1)) sr.color = Color.red;
        if (Input.GetKeyDown(KeyCode.Alpha2)) sr.color = Color.green;
        if (Input.GetKeyDown(KeyCode.Alpha3)) sr.color = Color.blue;
    }

    void FixedUpdate()
    {
        // Apply movement using Rigidbody2D – keeps effectors working
        Vector2 velocity = rb.velocity;
        velocity.x = xInput * speed;
        velocity.y = rb.velocity.y; // Keep vertical velocity for Buoyancy Effector
        rb.velocity = velocity;
    }
}