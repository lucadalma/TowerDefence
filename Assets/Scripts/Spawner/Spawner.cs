using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyToSpawn;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    float timeToSpawn;

    public int countSpawner = 0;

    private float nextActionTime = 0.0f;

    void Update()
    {
        SpawnEnemy();

        if (countSpawner == 15)
        {
            timeToSpawn = 2;
        }
    }

    public void SpawnEnemy() 
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += timeToSpawn;

            Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
            countSpawner++;

        }
    }
}
