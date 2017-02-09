
using UnityEngine;
using System.Collections;

public class DrawGizmos : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, 0.001f);
    }
}
