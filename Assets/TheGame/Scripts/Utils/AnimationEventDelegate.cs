using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventDelegate : MonoBehaviour
{
    public delegate void Callback();
    public static event Callback whenTimelineEventReached; //list 


    public void OnTimelineEvent()
    {
        if (whenTimelineEventReached != null)
            whenTimelineEventReached();
    }




}
