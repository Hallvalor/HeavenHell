using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGameObject : MonoBehaviour
{
    public Vector3 change = new Vector3();
    private static float pixelFrac = 1f / 16f;  //16 Pixel / per Unit
    private Animator animator; 

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void LateUpdate()
    {
        float step = roundToPixelGrid(1f * Time.deltaTime);
        animator.SetFloat("change_Y", change.y);
        animator.SetFloat("change_X", change.x);

        if (change.y <= -1f) animator.SetFloat("lookAt", 0f);
        else if (change.x <= -1f) animator.SetFloat("lookAt", 1f);
        else if (change.y >= 1f) animator.SetFloat("lookAt", 2f);
        else if (change.x >= 1f) animator.SetFloat("lookAt", 3f);

        Vector3 oldPos = transform.position;
        transform.position += change * step;
        change = Vector3.zero;
    }

    protected float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }
}
