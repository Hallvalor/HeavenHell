using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{   //Animates sprites
    
    public Sprite[] frames = new Sprite[0]; //list of sprites for destruction-animation
    public float duration = 0.5f;
    public bool loop = true;
    public bool destroyObject = false;

    public void OnEnable()
    {
        StartCoroutine(playAni());
    }


    protected IEnumerator playAni()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        do  //while the object is enabled (is false if object is deleted) && loop = true => animation forever
        {
            for (int i = 0; i < frames.Length; i++)
            {
                if (!enabled) break;
                sr.sprite = frames[i];
                yield return new WaitForSeconds(duration / frames.Length); //wait for xy sec (1 = 1 sec) //Game continues
            }
        }
        while (enabled && loop);

        if (destroyObject)
            Destroy(gameObject);
    }

}
