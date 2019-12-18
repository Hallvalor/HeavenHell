using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //is save-able
public class Health 
{
    public int currentHealth = 5;
    public int maxHealth = 5;

    public void change(int delta) //currentHealth never over max , delta => +/-  Healthpoints
    {
        currentHealth = Mathf.Clamp(currentHealth + delta, 0, maxHealth);

    }
}
