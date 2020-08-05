using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController2D controller;
    
    public float horizontalMove;
    public bool crouch = false;
    public bool jump = false;
    public float speed = 15;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal * speed;
        if(joystick.Vertical >= 0.5f)
        {
            jump = true;
            crouch = false;
        }
        else if(joystick.Vertical <= -0.5f)
        {
            jump = false;
            crouch = true;
        }
        else
        {
            jump = false;
            crouch = false;
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    }
}
