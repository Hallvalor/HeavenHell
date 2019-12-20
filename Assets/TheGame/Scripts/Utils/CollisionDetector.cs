using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    protected BoxCollider2D boxCollider;
    protected Collider2D[] colliders;
    protected ContactFilter2D obstacleFilter; //Hindernis
    public delegate void Callback(Collider2D collider);
    public Callback whenCollisionDetected;
    protected int numFound = 0; //collision num found

    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        colliders = new Collider2D[10];
        obstacleFilter = new ContactFilter2D();
    }

    protected void Update()
    {
        if (whenCollisionDetected == null)
        {
            Debug.Log("Fehler");
            enabled = false;
        }

        else if (isColliding())
        {
            for (int i = 0; i < numFound; i++)
            {
                whenCollisionDetected(colliders[i]);

            }

        }
    }

    protected bool isColliding()
    {
        Physics2D.SyncTransforms();
        numFound = boxCollider.OverlapCollider(obstacleFilter, colliders);
        return numFound > 0;
    }
}
