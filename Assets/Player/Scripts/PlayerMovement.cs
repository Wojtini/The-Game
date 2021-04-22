using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rb2d;

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    // Jumping
    public float jumpForce = 400f;
    public float jumpHold = 0f;
    public float maxJumpHold = 1f;
    public bool jump = false;



    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButton("Jump"))
        {
            jumpHold += Time.deltaTime;

            if ( jumpHold >= maxJumpHold )
            {
                jumpHold = maxJumpHold;
                jump = true;
            }
        }
        else if(jumpHold > 0) //Nie trzymam spacji ale trzymalem wczesniej
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        animator.SetBool("isRunning", horizontalMove != 0);

        if (jump)
        {
            animator.SetBool("jumpBool",true);
        }
        else
        {
            animator.SetBool("jumpBool", false);
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, jumpForce * (jumpHold/maxJumpHold));

        if (rb2d.velocity.y < -0.1)
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }

        if (jump)
        {
            jump = false;
            jumpHold = 0;
        }
    }
}
