using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : TheGameObject
{


    protected override void Awake()
    {
        base.Awake();

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
