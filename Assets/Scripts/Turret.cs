using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.9.11
/// </summary>

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float rotationSpeed = 5f;
    public float attackRange = 5f;
    public Transform attackPoint;
    public float attackCooldown = 2f;

    private Transform target;
    private float attackCooldownTimer = 0f;
    private Quaternion mainRotation;

    private void Start()
    {
        mainRotation = transform.rotation; // Store the main rotation at the start
    }

    private void Update()
    {
        FindNearestEnemy();

        if (target != null)
        {
            RotateTowardEnemy();
            Attack();
        }
        else
        {
            // If there's no enemy in attack range, rotate back to the main position
            transform.rotation = Quaternion.Slerp(transform.rotation, mainRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance && distanceToEnemy <= attackRange)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        target = nearestEnemy;
    }

    //void RotateTowardEnemy()
    //{
    //    Vector3 direction = target.position - transform.position;
    //    Quaternion lookRotation = Quaternion.LookRotation(direction);
    //    Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
    //    transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    //}

    void RotateTowardEnemy()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Rotate only around the z-axis
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
        //else
        //{
        //    // If there's no enemy in attack range, rotate back to the turret's main position
        //    Quaternion mainRotation = Quaternion.identity; // Modify this to set your turret's default rotation
        //    transform.rotation = Quaternion.Slerp(transform.rotation, mainRotation, Time.deltaTime * rotationSpeed);
        //}
    }

    void Attack()
    {
        if (attackCooldownTimer <= 0f)
        {
            if (target != null)
            {
                GameObject bulletGO = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
                Bullet bullet = bulletGO.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                attackCooldownTimer = attackCooldown;
            }
        }
        else
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }
}
