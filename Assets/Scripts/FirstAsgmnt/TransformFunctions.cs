using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFunctions : MonoBehaviour
{
    public bool isGlobal = true;

    public Transform obj = null;
    public float objX = 0;
    public float objY = 0;

    public Transform X = null;
    public Transform Y = null;

    private void OnDrawGizmos()
    {
        if (isGlobal)
        {
            objX = obj.position.x;
            objY = obj.position.y;
        }
        else
        {
            Vector3 temp = TransformToLocal();
            objX = temp.x;
            objY = temp.y;
        }
    }

    private Vector3 TransformToLocal()
    {
        Vector3 newPos = obj.position - transform.position;
        Vector3 result = new Vector3();

        Vector3 axisX = Vector3.Normalize(X.position - transform.position);
        Vector3 axisY = Vector3.Normalize(Y.position - transform.position);

        result.x = axisX.x * newPos.x + axisX.y * newPos.y;
        result.y = axisY.x * newPos.x + axisY.y * newPos.y;

        return result;
    }
}
