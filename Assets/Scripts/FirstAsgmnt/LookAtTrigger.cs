using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
    public AsgmntObject obj = null;

    [Range(0f, 1f)]
    public float threshold = 1f;

    private void OnDrawGizmos()
    {

        Vector3 objDir = obj.direction;
        Vector3 dir = Vector3.Normalize(obj.transform.position - transform.position);


        Gizmos.color = -(dir.x * objDir.x + dir.y * objDir.y) > threshold ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);

    }
}
