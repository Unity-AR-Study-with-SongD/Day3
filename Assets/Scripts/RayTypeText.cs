using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayTypeText : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private void Start ()
    {
        EventManager.inst.OnChangeRaytype += ChangeText;
    }

    public void ChangeText (RayType type)
    {
        if (type == RayType.cameraRay)
        {
            text.text = "Camera Ray";
        }
        else
        {
            text.text = "Touch point Ray";
        }
    }
}
