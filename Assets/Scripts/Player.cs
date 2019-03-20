using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    
    //config
    [SerializeField] float RunSpeed = 10f;
    [SerializeField] float JumpSpeed = 10f;
    [SerializeField] int  MaxHP;
    [SerializeField] ParticleSystem MyParticleSys;



    //State
    //bool isAlive = true;
    int CurrentHP;
    public Text healthText;
    bool FacingRight = true;

    //Cached Component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    Collider2D myCollider2D;
    FxControl MyFxControl;


    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
        MyFxControl = MyParticleSys.GetComponent<FxControl>();

        CurrentHP = MaxHP;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Run();
        Jump();
        Attack();
        HandleHealth();
	}


    // All control methods must be converted into states, in separate classes
    private void Run()
    {
        //CrossPlatformInputManager.GetAxis("Horizontal") -> between -1 and 1

        Vector2 playerVelocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * RunSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        float playerHSpeed = myRigidBody.velocity.x;

        if (playerHSpeed > 0 && !FacingRight)
        {
            Flip();
        }
        else if(playerHSpeed < 0 && FacingRight)
        {
            Flip();
        }


        if (myAnimator.GetBool("Jumping")) return;

        myAnimator.SetBool("Running", CrossPlatformInputManager.GetAxis("Horizontal") != 0);


    }

    private void Flip()
    {
            //rotates object in 180 degrees
            transform.Rotate(0f,180f,0f);
            FacingRight = !FacingRight;       
    }


    private void Jump()
    {
        //if input and character is not already jumping..
        if (CrossPlatformInputManager.GetButtonDown("Jump") && !myAnimator.GetBool("Jumping"))
        {         
                Vector2 jumpVelocityToAdd = new Vector2(0f, JumpSpeed);
                myRigidBody.velocity += jumpVelocityToAdd;
                myAnimator.SetBool("Jumping", true);

                Vector3 temp = new Vector2(0, 0.3f);
                transform.position += temp;
            return;
        }

        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myAnimator.SetBool("Jumping", false);
            myAnimator.SetBool("Fall", false);
        }



        if (myAnimator.GetBool("Jumping") && myRigidBody.velocity.y < 0)
        {
            myAnimator.SetBool("Fall", true);
        }

    }




    private void Attack()
    {
        if(CrossPlatformInputManager.GetButtonDown("BAtk"))
        {
            //Send the message to the Animator to activate the trigger parameter named "BAtk"
            myAnimator.SetTrigger("Attack");
            CurrentHP = CurrentHP - 5;
        }
    }

    private void HandleHealth()
    {
        healthText.text = "HP" + CurrentHP;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        MyFxControl.OnCollisionEnter2D(col);   
    }




    private void gameOver()
    {

    }



}
