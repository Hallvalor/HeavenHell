using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCrystal : Collectable
{ 
    void Start()
    {
        
    }

    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameData.currentSave.inventory.gems += 1;
        SaveGameData.currentSave.recordDestroy(gameObject);
    }
}
