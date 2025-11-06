using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5;
    public float horzDirection; //used to check which direction player is facing
    public bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horzDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horzDirection * speed, rb.velocity.y);

        //facing left and right logic
        if (horzDirection >= 0.01f)
        {
            transform.eulerAngles = new Vector3 (0,0,0); //facing right
        }
        if(horzDirection <= -0.01f)
        {
            transform.eulerAngles = new Vector3(0, -180, 0); //facing left
        }

        //jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, speed);
            isGrounded = false;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
