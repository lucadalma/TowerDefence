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

    private float nextActionTime = 0.0f;

    void Update()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy() 
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += timeToSpawn;

            Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);

        }
    }
}
