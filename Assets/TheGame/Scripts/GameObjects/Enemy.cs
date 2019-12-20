using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Start()
    {
        SaveGameData.currentSave.recoverDestroy(gameObject);
    }

    public void onHitBySword()
    {
        //if rdm-spawn-Object, rdm spawn? 
      //  RandomSpawn rs = GetComponent<RandomSpawn>();
        //if (rs != null)
        //{
        //    GameObject item = rs.spawn();  //RandomSpawn
        //    if (item != null)
        //    {
        //        item.transform.position = transform.position;
        //    }
        //}

     //   GameObject explosion = Instantiate(explosionPrototype, transform.parent);
      //  explosion.transform.position = transform.position;

        SaveGameData.currentSave.recordDestroy(gameObject);
    }
}
