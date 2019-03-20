using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShadow : MonoBehaviour
{
    [SerializeField] private GameObject ShadowCaster;
    [SerializeField] private float ShadowFadeScale;

    SpriteRenderer mySpriteRenderer;


    private void Start()
    {
        mySpriteRenderer = GetComponent <SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Fade();
    }

    private void Move()
    {
        transform.localPosition = new Vector2(ShadowCaster.transform.localPosition.x, transform.localPosition.y);  
    }
    private void Fade()
    {
        float opacity = 1f - (Mathf.Abs(transform.localPosition.y - ShadowCaster.transform.localPosition.y) / ShadowFadeScale);

        mySpriteRenderer.color = new Color(1f, 1f, 1f, opacity);
    }


}
