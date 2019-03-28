using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public Animator myAnimator;
    public Rigidbody2D myRigidBody2D;

    void start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //myAnimator.SetFloat("VSpeed", myRigidBody2D.velocity.y);
        Move();
        Jump();

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
    }


    void Move()
    {
        //horizontal movement Input check
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {

            myAnimator.SetBool("Running", true);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }
    }



    //Jump Input check
    void Jump()
    {
       
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            myAnimator.SetBool("Jumping", true);
        }
    }

    public  void OnLanding()
    {
        Debug.Log("I RAN!");
        
        myAnimator.SetBool("Falling", false);
        myAnimator.SetBool("Jumping", false);
        jump = false;
    }


}
