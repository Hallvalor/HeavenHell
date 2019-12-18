using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collectable : MonoBehaviour
{
    protected virtual void Awake()
    {
        if (!GetComponent<BoxCollider2D>().isTrigger) Debug.LogError("missing boxcollider-Trigger " + gameObject.name);
    }

    public virtual void OnCollect()
    {

    }

}
