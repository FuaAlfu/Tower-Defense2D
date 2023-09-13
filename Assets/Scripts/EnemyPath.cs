using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.9.10
/// </summary>

public class EnemyPath : MonoBehaviour
{
    public Transform[] waypoints;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}
