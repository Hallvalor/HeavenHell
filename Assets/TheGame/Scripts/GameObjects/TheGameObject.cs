using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGameObject : MonoBehaviour
{
    public Vector3 change = new Vector3();
    public float speed = 1f;
    protected BoxCollider2D boxCollider;
    protected Collider2D[] colliders;
    protected Animator anim;
    protected ContactFilter2D obstacleFilter; //Hindernis
    protected int numFound = 0; //Collision Objects Found

    private static float pixelFrac = 1f / 32f;  //16 Pixel / per Unit
    private Animator animator; 

    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        colliders = new Collider2D[10];
        obstacleFilter = new ContactFilter2D();

        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        
        animator.SetFloat("change_Y", change.y);
        animator.SetFloat("change_X", change.x);

        if (change.y <= -1f) animator.SetFloat("lookAt", 0f);
        else if (change.x <= -1f) animator.SetFloat("lookAt", 1f);
        else if (change.y >= 1f) animator.SetFloat("lookAt", 2f);
        else if (change.x >= 1f) animator.SetFloat("lookAt", 3f);

        float step = roundToPixelGrid(1f * Time.deltaTime);
        Vector3 oldPos = transform.position;
        transform.position += change * step * speed;

        if (isColliding())
        {
            transform.position = oldPos;
            for (int i = 0; i < numFound; i++)
            {
                TouchableBlocker tb = colliders[i].GetComponent<TouchableBlocker>();
                if (tb != null) tb.OnTouch();
            }
        }

        change = Vector3.zero;
    }

    //colliding with boxCollider of other objects? 
    protected bool isColliding()
    {
        Physics2D.SyncTransforms();
        numFound = boxCollider.OverlapCollider(obstacleFilter, colliders);
        return numFound > 0;
    }


    public Vector3 getFullTilePosition()
    {
        Vector3 p = transform.position;
        p.x = Mathf.FloorToInt(p.x); //Round downwards
        p.y = Mathf.CeilToInt(p.y); //Round upwards

        p.x += 0.5f;
        p.y -= 0.5f;

        return p;

    }

    public void pushByTiles(float deltaX, float deltaY)
    {
        Vector3 tilePos = getFullTilePosition();
        tilePos.x += deltaX;
        tilePos.y += deltaY;

        Vector3 oldPosition = getFullTilePosition();
        transform.position = tilePos;
        if (isColliding())
            transform.position = oldPosition;
        else StartCoroutine(animateMoveTowards(oldPosition, tilePos));
    }

    private IEnumerator animateMoveTowards(Vector3 fromPos, Vector3 targetPos)
    {
        float duration = 0.1f;
        for (float t = 0f; t <= 1f; t += Time.deltaTime / duration)
        {
            transform.position = Vector3.Lerp(fromPos, targetPos, t);
            yield return new WaitForEndOfFrame();
        }

    }

    public void pushAwayFrom(MonoBehaviour deflector, bool topLeftAnchor)
    {
        Vector3 diff;
        if (topLeftAnchor)  //topLeftAnchor
            diff = transform.position - (deflector.transform.position + new Vector3(0.5f, -0.5f, 0));
        else //middle
            diff = transform.position - deflector.transform.position;
        pushByTiles(diff.x, diff.y);

    }

    public virtual void flicker(int times)
    {
        StartCoroutine(animateFlicker(times));
    }

    private IEnumerator animateFlicker(int times)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        for (int i = 0; i < times; i++)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.05f);
        }
    }




    protected float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }
}
