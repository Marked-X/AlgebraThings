using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;

    private bool drag = false;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Camera.main.transform.position = origin - difference;
        }
    }
}
