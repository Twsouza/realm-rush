using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyToSpawn;
    [SerializeField] int maxEnemies = 5;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        spawnedEnemies.text = score.ToString();
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            AddScore();

            var enemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
