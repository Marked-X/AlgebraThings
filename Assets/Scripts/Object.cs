using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Object : MonoBehaviour
{
    public GameObject line = null;

    void Start()
    {
        
    }

    public void Rotate()
    {
        Vector3 direction = Algebra.Subtraction(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
