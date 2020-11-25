using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyToSpawn;
    [SerializeField] int maxEnemies = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        print("Max enemies: " + maxEnemies);
        while (FindObjectsOfType<EnemyMovement>().Length < maxEnemies)
        {
            Object.Instantiate(enemyToSpawn);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
