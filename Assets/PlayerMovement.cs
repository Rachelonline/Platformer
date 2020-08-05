using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController2D controller;
    public Animator animator;
    
    public float horizontalMove;
    public bool crouch = false;
    public bool jump = false;
    public float speed = 15;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if(joystick.Vertical >= 0.5f)
        {
            jump = true;
            animator.SetBool("isJumping", true);
            crouch = false;
            animator.SetBool("isCrouching", false);
        }
        else if(joystick.Vertical <= -0.5f)
        {
            jump = false;
            crouch = true;
            animator.SetBool("isCrouching", true);
        }
        else
        {
            jump = false;
            crouch = false;
            animator.SetBool("isCrouching", false);
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    }

    public void OnLand()
    {
        animator.SetBool("isJumping", false);
    }
}
