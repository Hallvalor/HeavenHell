using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Hero hero;

    private void Update()
    {
        Vector3 heroPos = hero.transform.position;
        heroPos.z = transform.position.z;
        transform.position = heroPos;


    }

}
