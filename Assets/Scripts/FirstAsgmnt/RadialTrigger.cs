using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RadialTrigger : MonoBehaviour
{
    public Transform obj;

    [Range(0f, 4f)]
    public float radius = 1f;

    private void OnDrawGizmos()
    {
        Vector2 dist = obj.position - transform.position;
        float distance = Mathf.Sqrt(dist.x * dist.x + dist.y * dist.y);

        Handles.color = distance <= radius ? Color.green : Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
    }
}
