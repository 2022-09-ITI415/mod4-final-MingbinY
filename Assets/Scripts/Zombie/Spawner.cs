using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    public int maxZombieRespawn = 10;
    public float spawnInterval = 5f;
    public float nextSpawnTime;
    int spawnCount = 0;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        RestartSpawn();
    }

    private void Update()
    {
        if (spawnCount >= maxZombieRespawn)
            return;
        if (Time.time > nextSpawnTime)
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        nextSpawnTime = Time.time + spawnInterval;
        spawnCount++;
        if (spawnCount >= maxZombieRespawn)
        {
            Invoke("RestartSpawn", 120f);
        }

        Instantiate(zombiePrefab, transform.position, Quaternion.identity);
    }

    void RestartSpawn()
    {
        spawnCount = 0;
    }
}
