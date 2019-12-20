using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Weapon : Collectable
{
    public void Start()
    {
        if (SaveGameData.currentSave.inventory.weapon) Destroy(gameObject);
    }

    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameData.currentSave.inventory.weapon = true;
        Destroy(gameObject);
    }

}
