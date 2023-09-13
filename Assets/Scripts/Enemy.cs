using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.9.10
/// 
/// super class
/// </summary>

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject effectPrefabe;

    public int HP { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
      //  Die();
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(effectPrefabe, transform.position, Quaternion.identity);
        GameSession.Instance.AddToScore(10);
        Destroy(gameObject);
    }
}
