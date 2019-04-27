using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaftormerController : PhysicsObject
{
    public float jumpTakeOffSpeed = 7;
    public float maxSpeed = 7;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;
    private Player myPlayer;


    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myPlayer = GetComponent<Player>();
    }


    //called during update
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            groundNormal.y = 1;
            groundNormal.x = 0;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }


        //Animate
        myAnimator.SetBool("grounded",grounded);
        myAnimator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        myAnimator.SetFloat("velocityY", velocity.y);

        //flipSprite
        flipSprite(move.x);

        
    
        if(Input.GetButtonDown("BAtk"))
        {
            //Send the message to the Animator to activate the trigger parameter named "BAtk"
            myAnimator.SetTrigger("Attacking");
            myPlayer.CurrentHP -= 200;



            FindObjectOfType<AudioManager>().Play("Attack");
        }
      





        //set the targetspeed
        targetVelocity = move * maxSpeed;
    }

 


    private void flipSprite(float move)
    {
        bool flipSprite = mySpriteRenderer.flipX ? (move < -0.01f) : (move > 0.01f);
        if (flipSprite)
        {
            mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
        }
        
    }
}
