using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgebraController : MonoBehaviour
{
    [SerializeField]
    private GameObject firstObject = null;
    [SerializeField]
    private GameObject secondObject = null;

    public delegate void DragAction();
    public static event DragAction OnDrag;

    private GameObject selectedObject = null;
    private Vector3 offset;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
                
            }
        }
        if (selectedObject == firstObject || selectedObject == secondObject)
        {
            selectedObject.transform.position = mousePosition + offset; 
            OnDrag();
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;

        }
    }
}
