using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour 
{
    public List<Transform> SpawnPoints = new List<Transform>();
    public GameObject GameobjectToSpawn;

    public int Count;
    public float SpawnDelay;
    public bool SpawnRandomOrder = false;
    public bool StartSpawning = false;

    private int spawnIndex = 0;
    private int spawnCount = 0;

    void Update()
    {
        if (StartSpawning)
        {
            StartCoroutine(SpawnTimer());
            StartSpawning = false;
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(SpawnDelay);
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(GameobjectToSpawn, ChoosePosition(), Quaternion.identity);
        if (spawnCount < Count)
            StartCoroutine(SpawnTimer());
    }

    private Vector3 ChoosePosition()
    {
        if (SpawnRandomOrder)
        {
            int i = Random.Range(0, SpawnPoints.Count);

            return SpawnPoints[i].position;
        }
        else
        {
            spawnIndex++;

            if (spawnIndex > SpawnPoints.Count - 1)
                spawnIndex = 0;

            return SpawnPoints[spawnIndex].position;
        }
    }
}
