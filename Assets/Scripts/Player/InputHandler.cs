using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    public class InputHandler : MonoBehaviour
    {

        [Range(-1, 1)] public float vertical;
        Animator myAnimator;
        
        void Start()
        {
            myAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            myAnimator.SetFloat("Vertical", vertical);
        }
    }
}