using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement player;

    public ParticleSystem dust;

    public float speed;
    public float jump;


    public Transform ceiling;
    public Transform ground;
    public LayerMask gmask;
    public float gradius;
    public int maxJumps;

    Animator anim;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float move;
    private bool jumping = false;
    private bool grounded;
    private int jumps;

    // called before scene is loaded
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        jumps = maxJumps;
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
        if (grounded)
        {
            jumps = maxJumps;
        }

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
        if(Input.GetKeyDown(KeyCode.X) && jumps > 0)
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
            rb.velocity = new Vector2(rb.velocity.x, jump);
            jumps --;
        }
        jumping = false;
    }

    private void Flip()
    {
        Dust();
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goldCoin"))
        {
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("silverCoin"))
        {
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("bronzeCoin"))
        {
            Destroy(other.gameObject);

        }

        /*
        if (other.gameObject.CompareTag("enemy"))
        {
            ScoreManager.instance.ChangeHealth(MobAI.mob.bodyDamage);
        }
        */
    }

    public void TakeHit()
    {
        ScoreManager.instance.ChangeHealth(MobAI.mob.bodyDamage);
    }

    void Dust()
    {
        dust.Play();
    }
}
