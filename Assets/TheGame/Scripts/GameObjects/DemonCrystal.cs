using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCrystal : Collectable
{
    public void Start()
    {
        SaveGameData.currentSave.recoverDestroy(gameObject); //if GameObject is destroyed -> destroy on save
    }

    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameData.currentSave.inventory.gems += 1;
        SaveGameData.currentSave.recordDestroy(gameObject);
    }
}
