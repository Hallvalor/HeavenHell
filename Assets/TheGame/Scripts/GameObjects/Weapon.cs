using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public Animator animator;
    public Animator characterAnimator;
    public CollisionDetector collisionDetector; 

    protected void Start()
    {
        setVisible(false);
        collisionDetector.whenCollisionDetected = onCollisionDetected;
    }

    public void OnEnable()
    {
        AnimationEventDelegate.whenTimelineEventReached += onTimelineEvent; 
    }

    public void OnDisable()
    {
        AnimationEventDelegate.whenTimelineEventReached -= onTimelineEvent; 
    }

    private void onCollisionDetected(Collider2D collider)
    {
        //Bush bush = collider.GetComponent<Bush>();
        //if (bush != null) bush.onHitBySword();

        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null) enemy.onHitBySword();


    }

    private void setVisible(bool isVisible)
    {
        animator.gameObject.SetActive(isVisible); 
    }

    public void stroke() //move stroke in right direction
    {
        int lookAt = Mathf.RoundToInt(characterAnimator.GetFloat("lookAt"));

        float scaleX = 1f;
        float rotateZ = 0f;
        if (lookAt == 0)
        {
            rotateZ = 90f;
          
        }
        else if (lookAt == 2) rotateZ = -90f;
        else if (lookAt == 3) scaleX = -1f;
       
        transform.localScale = new Vector3(scaleX, 1f, 1f);
        transform.localRotation = Quaternion.Euler(0f, 0f, rotateZ);

        setVisible(true); 

        animator.SetTrigger("onStroke");
   
    }


    public void onTimelineEvent()
    {
        setVisible(false);
    }

}
