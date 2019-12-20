using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputController : MonoBehaviour
{
    public Hero hero;

    void Update()
    {
        if (Time.timeScale < 1f) return; //if pause -> no actions


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            hero.change.x = 1;
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            hero.change.x = -1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            hero.change.y = 1;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            hero.change.y = -1;

       else  if (Input.GetKeyUp(KeyCode.E))
        {
            hero.performAction();
        }

        //else if (Input.GetKeyUp(KeyCode.F))
        //{
        //    hero.StartDialog(); 
        //}

    }
}
