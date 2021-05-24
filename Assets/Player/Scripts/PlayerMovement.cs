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
    //Dashing
    public bool canDash = false;
    public float dashForce = 400f;
    public bool dash = false;
    //Freeze
    private bool freezed = false;

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
        }
        else if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetKeyDown("left shift"))
        {
            Debug.Log("git");
            dash = true;
        }
        
        //for more frequent update
        animator.SetBool("isFalling", rb2d.velocity.y < -0.05);

    }

    private void FixedUpdate()
    {
        if (freezed)
            return;
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, jumpForce, dash, dashForce);




        animator.SetBool("isRunning", horizontalMove != 0);
        animator.SetBool("jumpBool", jump);
        jump = false;
        dash = false;
    }

    public void SetFreezePlayerMovement(bool freezed)
    {
        this.freezed = freezed;
    }
}
