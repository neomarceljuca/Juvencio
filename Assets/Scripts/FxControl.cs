using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxControl : MonoBehaviour
{
   
    ParticleSystem myParticleSys;
    [SerializeField] Player Source;


    void Start()
    {
        myParticleSys = GetComponent<ParticleSystem>();

        var emission = myParticleSys.emission;
        emission.enabled = false;
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D col)
    {
        transform.position = Source.transform.position;
        myParticleSys.Emit(50);
    }





}
