using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController2D controller;
    public Animator animator;

    public float horizontalMove;
    public bool isJumping;
    public bool isCrouching;
    public bool canJump = true;
    public float speed = 0.5f;

    void Update()
    {
        horizontalMove = joystick.Horizontal * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("Crouching", isCrouching);
        animator.SetBool("Jumping", isJumping);

        if(joystick.Vertical >= 0.5f)
        {
            if (canJump)
            {
                isJumping = true;
                canJump = false;
                Invoke("StopJumping", 0.5f);
            }
            isCrouching = false;
        }
        else if(joystick.Vertical <= -0.5f)
        {
            isJumping = false;
            canJump = true;
            isCrouching = true;
            horizontalMove = 0f;
        }
        else
        {
            isJumping = false;
            canJump = true;
            isCrouching = false;
        }
    }

    public void StopJumping()
    {
        isJumping = false;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove, isCrouching, isJumping);
    }
}
