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
    public int CurrentHP;
    public Text healthText;
    public bool gameOver = false;
 
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
        
	}



    private void HandleHealth()
    {
        healthText.text = "HP" + CurrentHP;

        if (CurrentHP <= 0) gameOver = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        MyFxControl.OnCollisionEnter2D(col);   
    }




  



}
