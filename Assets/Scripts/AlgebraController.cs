using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgebraController : MonoBehaviour
{
    [SerializeField]
    private GameObject firstObject = null;
    [SerializeField]
    private Text firstObjectAngle = null;
    [SerializeField]
    private GameObject secondObject = null;
    [SerializeField]
    private Text secondObjectAngle = null;
    [SerializeField]
    private Text scalar = null;
    [SerializeField]
    private Text vectorBetween = null;
    [SerializeField]
    private Text vectorBetweenLength = null;
    [SerializeField]
    private Text vectorBetweenNormalized = null;

    public delegate void DragAction();
    public static event DragAction OnDrag;

    private GameObject selectedObject = null;
    private Vector3 offset;

    private void Start()
    {
        CalculateVector();
    }

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
            CalculateVector();
            OnDrag();
        }
        else if (selectedObject == firstObject.GetComponent<Object>().line)
        {
            firstObject.GetComponent<Object>().Rotate();
            firstObjectAngle.text = firstObject.GetComponent<Object>().angle.ToString();
        }
        else if (selectedObject == secondObject.GetComponent<Object>().line)
        {
            secondObject.GetComponent<Object>().Rotate();
            secondObjectAngle.text = secondObject.GetComponent<Object>().angle.ToString();
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
            CalculateScalar();
        }
    }

    private void CalculateScalar()
    {
        float firstAngle = firstObject.GetComponent<Object>().angle * Mathf.Deg2Rad;
        float secondAngle = secondObject.GetComponent<Object>().angle * Mathf.Deg2Rad;

        Vector3 first = new Vector3(Mathf.Cos(firstAngle), Mathf.Sin(firstAngle), 0);
        Vector3 second = new Vector3(Mathf.Cos(secondAngle), Mathf.Sin(secondAngle), 0);

        scalar.text = Algebra.ScalarProduct(first, second).ToString();
    }

    private void CalculateVector()
    {
        Vector3 temp = Algebra.Subtraction(secondObject.transform.position, firstObject.transform.position);
        vectorBetween.text = temp.x + " " + temp.y;
        vectorBetweenLength.text = Algebra.Length(temp).ToString();
    }
}
