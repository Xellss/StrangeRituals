using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject GameobjectToSpawn;

    public List<Transform> SpawnPoints = new List<Transform>();

    public int Count;

    [Range(0, 10)]
    public float SpawnDelay;
    public bool RandomOrder = false;
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

    public void StartNewWave(GameObject toSpawn ,int count, float spawnDelay, bool spawnRandomOrder)
    {
        spawnCount = 0;
        this.GameobjectToSpawn = toSpawn;
        this.Count = count;
        this.SpawnDelay = spawnDelay;
        this.RandomOrder = spawnRandomOrder;

        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(SpawnDelay);
        Spawn();
    }

    private void Spawn()
    {
        spawnCount++;
        Instantiate(GameobjectToSpawn, ChoosePosition(), Quaternion.identity);
        if (spawnCount < Count)
            StartCoroutine(SpawnTimer());
    }

    private Vector3 ChoosePosition()
    {
        if (RandomOrder)
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
