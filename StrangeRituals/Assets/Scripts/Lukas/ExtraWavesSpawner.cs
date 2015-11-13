using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExtraWavesSpawner : MonoBehaviour
{
    [Space(20)]
    [Tooltip("Attach the Gamemanager of the Scene")]
    public GameManager GameManager;

    [Tooltip("Activate this to Randomize the SpawnOrder")]
    public bool RandomSpawnOrder;

    [Space(20)]
    public List<GameObject> EnemysToSpawn = new List<GameObject>();
    public List<Transform> EnemySpawnPoints = new List<Transform>();

    [Header("Start Parameters for the Spawner:")]
    [Space(20)]
    [Range(0f, 20f)]
    public float SpawnDelay;
    public int Amount;

    [Header("Parameters To Add for every Spawned Wave:")]
    [Space(20)]
    [Range(-10f, 10f)]
    public float SpawnDelayToDecrease;
    public int AmountToAdd;

    private int SpawnCounter = 0;
    private int SpawnOrderCounter = 0;

    void Update()
    {
        if (GameManager.SpawnExtraWave)
        {
            StartCoroutine(SpawnTimer());
            GameManager.SpawnExtraWave = false;
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(SpawnDelay);
        Spawn();
    }

    private void Spawn()
    {

        if (SpawnCounter < Amount)
        {
            Instantiate(GetRandomEnemy(), GetSpawnPoint(), Quaternion.identity);
            SpawnCounter++;

            StartCoroutine(SpawnTimer());
        }

        else
            UpdateSpawnerParameters();
    }

    private void UpdateSpawnerParameters()
    {
        SpawnDelay += SpawnDelayToDecrease;
        Amount += AmountToAdd;
    }

    private GameObject GetRandomEnemy()
    {
        return EnemysToSpawn[Random.Range(0, EnemysToSpawn.Count)];
    }

    private Vector3 GetSpawnPoint()
    {
        if (RandomSpawnOrder)
            return EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].position;
        else
        {
            Vector3 tempPos = EnemySpawnPoints[SpawnOrderCounter].position;
            SpawnOrderCounter++;

            if (SpawnOrderCounter > EnemySpawnPoints.Count - 1)
                SpawnOrderCounter = 0;

            return tempPos;
        }
    }
}