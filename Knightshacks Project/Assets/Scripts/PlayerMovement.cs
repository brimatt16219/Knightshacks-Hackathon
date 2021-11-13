using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jump;



    private Rigidbody2D rb;
    private bool facingRight = true;
    private float move;
    private bool jumping = false;

    // called before scene is loaded
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //get player input
        
        GetInput();

        Turn();

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Turn()
    {
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    private void GetInput()
    {
        move = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            jumping = true;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (jumping)
        {
            rb.AddForce(new Vector2(0f, jump));
        }
        jumping = false;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
