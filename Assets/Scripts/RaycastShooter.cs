using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooter : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hitPoint;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask mask;

    private void Update ()
    {
        if (EventManager.inst.currentRayType == RayType.touchPointRay)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                ShootRay();
            }
            else
            {
                if (EventManager.inst.OnRayRelease != null)
                {
                    EventManager.inst.OnRayRelease.Invoke();
                }
            }
        }
        else
        {
            ray.origin = cam.transform.position;
            ray.direction = cam.transform.forward;

            ShootRay();
        }
    }

    private void ShootRay ()
    {
        if (Physics.Raycast(ray.origin, ray.direction, out hitPoint, Mathf.Infinity, mask))
        {
            if (EventManager.inst.OnRayHit != null)
            {
                EventManager.inst.OnRayHit.Invoke(hitPoint);
            }
        }
        else
        {
            if (EventManager.inst.OnRayRelease != null)
            {
                EventManager.inst.OnRayRelease.Invoke();
            }
        }
    }

    public void ChangeRayType ()
    {
        if (EventManager.inst.currentRayType == RayType.touchPointRay)
        {
            EventManager.inst.currentRayType = RayType.cameraRay;
        }
        else
        {
            EventManager.inst.currentRayType = RayType.touchPointRay;
        }

        if (EventManager.inst.OnChangeRaytype != null)
        {
            EventManager.inst.OnChangeRaytype.Invoke(EventManager.inst.currentRayType);
        }
    }
}
