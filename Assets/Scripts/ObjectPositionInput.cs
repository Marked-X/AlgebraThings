using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPositionInput : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPosition = null;

    private InputField inputField = null;

    private void OnEnable()
    {
        AlgebraController.OnDrag += RewritePosition;
    }

    void Start()
    {
        inputField = GetComponent<InputField>();
        inputField.text = objectPosition.transform.position.ToString();
    }

    private void OnDisable()
    {
        AlgebraController.OnDrag -= RewritePosition;
    }

    public void OnValueChanged()
    {
        string[] newValues = inputField.text.Split(',');
        objectPosition.transform.position = new Vector3(float.Parse(newValues[0]), float.Parse(newValues[1]), float.Parse(newValues[2]));
    }

    private void RewritePosition()
    {
        inputField.text = objectPosition.transform.position.ToString();
    }
}
