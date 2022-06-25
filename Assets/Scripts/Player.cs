using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float smooth;
    public float jumpForce;
    bool facingRight = true;
    bool grounded;
    public Collider2D groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D rb2d;
    public Animator animator;
 
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }


    void Update()
    {
        // Is the player touching the ground ?
        grounded = groundCheck.IsTouchingLayers(groundLayer);

        animator.SetBool("Jumping", !grounded);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            rb2d.AddForce(new Vector2(0f, jumpForce));
        // Only jump if the player is grounded and has pressed the Space bar

    }




    void FixedUpdate()
    {
        //Get Input
        float x = Input.GetAxisRaw("Horizontal");
        animator.SetBool("Running", x != 0);
        //Update the player's velocity
        Vector2 targetVelocity = new Vector2(x * speed, rb2d.velocity.y);

        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref targetVelocity, Time.deltaTime * smooth);

        //if the input is moving the player right and the player is facing left...
        if (x > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (x < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    void Flip()
    {
        //Invert the facingRight variable
        facingRight = !facingRight;

        //Flip the Character
        Vector2 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }


}


