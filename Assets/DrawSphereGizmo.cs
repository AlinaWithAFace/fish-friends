using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSphereGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 1f);
    }
}
