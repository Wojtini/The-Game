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
    private float currJumpCooldown = 0f;
    public float jumpCooldown = 1f;
    public float jumpForce = 400f;
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

        if (currJumpCooldown > 0f)
        {
            currJumpCooldown -= Time.deltaTime;
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
        //for more frequent update
        animator.SetBool("isFalling", rb2d.velocity.y < -0.05);

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, jumpForce);




        animator.SetBool("isRunning", horizontalMove != 0);
        animator.SetBool("jumpBool", jump);
        jump = false;
    }
}
