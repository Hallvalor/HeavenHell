using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : Collectable
{
    private float lockedUntil = 0f;
    public SpriteAnimator unlockedSprites;
    public Sprite lockedSprite;
    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        if (SaveGameData.currentSave.savepoint == (gameObject.scene.name + "/" + gameObject.name)) //last saved savepoint
        {
            setLocked(true);
            FindObjectOfType<Hero>().transform.position = transform.position + new Vector3(0.5f, -0.5f, 0f);
        }
    }

    public void Update()
    {
        setLocked(isLocked());
    }

    public override void OnCollect()
    {
        base.OnCollect();

        if (isLocked()) return;
        SaveGameData.currentSave.savepoint = gameObject.scene.name + "/" + gameObject.name;
        SaveGameData.currentSave.save();
        setLocked(true);
    }

    private void setLocked(bool doLock)  //locks the savepoint to not save
    {
        if (doLock != unlockedSprites.enabled) return;
        if (doLock)
        {
            lockedUntil = Time.time + 10f;  //save is possible in 10 sec after lock
            unlockedSprites.enabled = false;
            spriteRenderer.sprite = lockedSprite;
        }
        else
        {
            unlockedSprites.enabled = true;

        }
    }

    private bool isLocked()  //save possible or savepoint locked? 
    {
        return lockedUntil > Time.time;
    }
}
