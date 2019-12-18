using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : TheGameObject
{
    private ContactFilter2D triggerContactFilter;

    protected override void Awake()
    {
        base.Awake();
        triggerContactFilter = new ContactFilter2D();
        triggerContactFilter.useTriggers = true;  //notices trigger
    }

    private void Update()
    {
        Physics2D.SyncTransforms();
        int found = boxCollider.OverlapCollider(triggerContactFilter, colliders);
        for (int i = 0; i < found; i++)
        {
            Collider2D collider = colliders[i];
            if (collider.isTrigger)
            {
                foreach (Collectable collectible in collider.GetComponents<Collectable>())
                {
                    collectible.OnCollect();
                }
            }
        }


    }

    public override void flicker(int times)
    {
       // hitSound.Play();
        base.flicker(times);
    }


    [System.Serializable]
    public class SpriteSet
    {
        public Sprite down;
        public Sprite left;  //and right with mirror
        public Sprite up;
        public Sprite right;

        public void apply(SpriteRenderer spriteRenderer, int lookAt)
        {
            if (lookAt == 0)
                spriteRenderer.sprite = down;
            else if (lookAt == 1)
                spriteRenderer.sprite = left;
            else if (lookAt == 2)
                spriteRenderer.sprite = up;
            else if (lookAt == 3)
            {
                spriteRenderer.sprite = right;
                spriteRenderer.flipX = true;
            }

        }


      
    }
}
