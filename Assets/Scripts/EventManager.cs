using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager inst = null;
    private void Awake ()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Action<RaycastHit> OnRayHit;
    public Action<RayType> OnChangeRaytype;
    public Action OnTouchScreen;
    public Action OnRayRelease;

    public RayType currentRayType;
}
