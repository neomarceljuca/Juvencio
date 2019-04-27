using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchFor : IState
{
    private LayerMask searchLayer;
    private GameObject ownerGameObject;
    private float searchRadius;
    private string searchedTag;


    public SearchFor(LayerMask searchLayer, GameObject ownerGameObject, float searchRadius, string searchedTag)
    {

        this.ownerGameObject = ownerGameObject;
        this.searchRadius = searchRadius;
        this.searchedTag = searchedTag;
        this.searchLayer = searchLayer;
}



    public void Enter()
    {

    }


    public void Execute()
    {
        
        var hitObjects = Physics2D.OverlapCircleAll(this.ownerGameObject.transform.position, searchRadius);


        for (int i =0; i< hitObjects.Length ; i++)
        {
            if (hitObjects[i].CompareTag(searchedTag))
            {
                Debug.Log(" Searching object sees " + searchedTag + searchLayer);
            }
        }   

    }


    public void Exit()
    {

    }

}
