using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    public int maxZombieRespawn = 10;
    public float spawnInterval = 5f;
    public float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        nextSpawnTime = Time.time + spawnInterval;
        Instantiate(zombiePrefab, transform.position, Quaternion.identity);
    }
}
