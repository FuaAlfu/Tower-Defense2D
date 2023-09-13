using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.9.10
/// </summary>

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyType
    {
        Drak,
        Light,
        Fire,
        Ice
    }

    public Transform[] waypoints;
    private float speed;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        //add switch statement to modyfide the speed
        speed = Random.Range(2f, 5f);
    }

    private void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // Reached the end of the path; destroy the enemy or deduct player health.
            //playerHealth--;
            Destroy(gameObject);
        }
    }
}
