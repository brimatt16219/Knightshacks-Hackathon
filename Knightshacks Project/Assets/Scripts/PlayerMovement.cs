using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jump;

    public Transform ceiling;
    public Transform ground;
    public LayerMask gmask;
    public float gradius;

    Animator anim;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float move;
    private bool jumping = false;
    private bool grounded;

    // called before scene is loaded
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        grounded = Physics2D.OverlapCircle(ground.position, gradius, gmask);
        Move();
        if (rb.velocity != Vector2.zero)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
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
        if(Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
        }
        anim.SetBool("jumping", !grounded);
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
