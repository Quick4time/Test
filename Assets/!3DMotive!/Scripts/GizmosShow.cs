using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosShow : MonoBehaviour
{
    [SerializeField]
    private bool ShowGizmos = true;
    [SerializeField]
    private string MyIcon = string.Empty;

    [Range(0f, 100f)]
    public float Range = 10.0f;

    private void OnDrawGizmos()
    {
        // Выходим из метода если ShowGizmos = false;
        if (!ShowGizmos) return;

        // Draw selected icon
        Gizmos.DrawIcon(transform.position, MyIcon, true);

        // Draw Color wire sphere
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);

        // Draw forward vector
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * Range);
    }
}
