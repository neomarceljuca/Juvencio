using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowRenderer : MonoBehaviour
{
    [SerializeField] private GameObject ShadowCaster;
    public LayerMask mask;
    float ShadowFadeScale = 7f;
    Vector2 SpriteOffset = new Vector2(0f, 1.4f);


    SpriteRenderer mySpriteRenderer;
    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Cast();
        Fade();
    }

    private void Cast()
    {

        Ray2D ray = new Ray2D(ShadowCaster.transform.position, -Vector2.up);
        RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction, 10, mask);

        if (hitInfo)
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            transform.localPosition = hitInfo.point + SpriteOffset;

        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10, Color.green);
        }
    }

    private void Fade()
    {
        float opacity = 1f - (Mathf.Abs(transform.localPosition.y - ShadowCaster.transform.localPosition.y) / ShadowFadeScale);

        mySpriteRenderer.color = new Color(1f, 1f, 1f, opacity);
    }



}
