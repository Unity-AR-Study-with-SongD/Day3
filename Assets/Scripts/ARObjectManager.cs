using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject objPrefab;
    private GameObject rayPointer;

    private void Start ()
    {
        rayPointer = Instantiate(objPrefab);

        EventManager.inst.OnRayHit += OnRayHit;
        EventManager.inst.OnRayRelease += OnRayRelease;
    }

    private void OnRayHit (RaycastHit hitPoint)
    {
        rayPointer.SetActive(true);
        rayPointer.transform.position = hitPoint.point;
    }

    private void OnRayRelease ()
    {
        rayPointer.SetActive(false);
    }
}
