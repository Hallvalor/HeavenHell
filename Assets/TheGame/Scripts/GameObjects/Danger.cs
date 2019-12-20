using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]  //Danger-class needs a BoxCollider2D!
public class Danger : TouchableBlocker
{
    private float lastHit = 0f; //time of last hit on player
    public bool topLeftAnchor = true;
    public bool shieldProtection = false;

    public override void OnTouch()
    {
        base.OnTouch();
        if (Time.time - lastHit > 1f) //if 1 sec passed, hit again
        {
            //  bool isSafe = shieldProtection && SaveGameData.currentSave.inventory.shield;
            bool isSafe = shieldProtection;
            if (!isSafe) SaveGameData.currentSave.health.change(-1);
            lastHit = Time.time;

            if (SaveGameData.currentSave.health.currentHealth > 0)
            {
                Hero hero = FindObjectOfType<Hero>();
                hero.pushAwayFrom(this, topLeftAnchor);
                if (!isSafe) hero.flicker(5);
            }

        }
    }
}