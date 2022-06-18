using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Object : MonoBehaviour
{
    public GameObject line = null;
    public float angle = 0;

    void Start()
    {
        
    }

    public void Rotate()
    {
        Vector3 direction = Algebra.Subtraction(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }
}
