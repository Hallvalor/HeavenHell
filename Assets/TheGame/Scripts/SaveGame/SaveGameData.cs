using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameData
{
   // public Inventory inventory = new Inventory();
  //  public Health health = new Health();
    public string savepoint = ""; //last savepoint
    public List<string> deletedObjects = new List<string>(); //list of ID of the deleted items for savegame

    // Update is called once per frame
    void Update()
    {
        
    }
}
