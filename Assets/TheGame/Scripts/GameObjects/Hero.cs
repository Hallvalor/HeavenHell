using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : TheGameObject
{
    private ContactFilter2D triggerContactFilter;
    public DialogueManager dialogueManager; 

    public RuntimeAnimatorController emptySkin;  //skin without shield etc
    public SpriteSet emptyActionSkin;

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

                if (collider.tag == "DialogueZone" && Input.GetKeyDown(KeyCode.Space))
                {
                    dialogueManager.ShowBox(collider.GetComponentInParent<DialogueNPC>());
                }

            }



        }



        if (SaveGameData.currentSave.health.currentHealth == 0)
        {
            animator.SetTrigger("die");
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;  //ignore timesScale = 0f, animation continues
            GetComponent<HeroInputController>().enabled = false;

            Time.timeScale = 0f;  //"pause" game
            AudioListener.pause = true;
        }

    }

    //Death
    public void onDeathAnimationComplete()
    {
        DialogUI dui = FindObjectOfType<DialogUI>();
        dui.gameOverDialog.SetActive(true);
    }

    ////StartDialog / Action
    //public void StartDialog()
    //{
    //    float  test; 
    //    test  =  animator.GetFloat("lookAt");
    //    Debug.Log("LookAt : " + test);


    //}




    //Stroke and use correct skin
    public void performAction()
    {
        if (!SaveGameData.currentSave.inventory.weapon) return;  //no sword - no hit
        animator.enabled = false;

        AnimationEventDelegate.whenTimelineEventReached += resetSkin;

       // if (SaveGameData.currentSave.inventory.shield) shieldActionSkin.apply(GetComponent<SpriteRenderer>(), Mathf.RoundToInt(anim.GetFloat("lookAt")));
        emptyActionSkin.apply(GetComponent<SpriteRenderer>(), Mathf.RoundToInt(animator.GetFloat("lookAt")));
//
        Weapon weapon = GetComponentInChildren<Weapon>();
        weapon.stroke();
    }

    private void resetSkin()
    {
        animator.enabled = true;
        AnimationEventDelegate.whenTimelineEventReached -= resetSkin;
    }


    //flicker if e.g. get hit
    public override void flicker(int times)
    {
       // hitSound.Play();
        base.flicker(times);
    }

    //for custom sprite-set (empty skin, shieldskin, perhaps angel-skin?) 
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
