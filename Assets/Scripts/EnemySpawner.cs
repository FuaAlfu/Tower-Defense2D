using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.9.10
/// </summary>

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject vfxPrefabe;

    [SerializeField]
    private Transform path;

    [SerializeField]
    private int enemyLimits = 5;

    private int enemyCount = 0;

    private void Start()
    {
        //SpawnEnemy();

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(2f,3f));
            SpawnEnemy();
            enemyCount++;
            if(enemyCount > enemyLimits)
            {
                break;
            }
        }
       
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        GameObject vfx = Instantiate(vfxPrefabe, transform.position, Quaternion.identity);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.waypoints = path.GetComponent<EnemyPath>().waypoints;
    }
}
