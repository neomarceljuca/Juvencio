using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    //config
    [SerializeField] int  MaxHP;
    [SerializeField] ParticleSystem MyParticleSys;



    //State
    //bool isAlive = true;
    int CurrentHP;
    public Text healthText;
 
    //Cached Component references
    FxControl MyFxControl;


    void Start ()
    {
        MyFxControl = MyParticleSys.GetComponent<FxControl>();
        CurrentHP = MaxHP;
	}
	
	void Update ()
    {
        HandleHealth();
        Attack();
	}


    private void Attack()
    {
        if(Input.GetButtonDown("BAtk"))
        {
            //Send the message to the Animator to activate the trigger parameter named "BAtk"
           // myAnimator.SetTrigger("Attack");
            CurrentHP = CurrentHP - 5;



            FindObjectOfType<AudioManager>().Play("Attack");
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
