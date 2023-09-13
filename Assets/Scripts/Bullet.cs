using UnityEngine;

/// <summary>
/// 2023.9.12
/// </summary>

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public GameObject hitEffect;
    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Apply damage to the enemy (you should have an Enemy script with a TakeDamage method).
         target.GetComponent<Enemy>().TakeDamage(damage);
        Instantiate(hitEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
