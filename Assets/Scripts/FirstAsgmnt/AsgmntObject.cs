using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsgmntObject : MonoBehaviour
{
    public Transform point = null;

    public Vector3 direction = Vector3.zero;

    private void OnDrawGizmos()
    {

        direction = Vector3.Normalize(point.position - transform.position);

        Gizmos.DrawLine(transform.position, transform.position + direction);

    }
}
