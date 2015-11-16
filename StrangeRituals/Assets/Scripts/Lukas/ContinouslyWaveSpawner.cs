using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContinouslyWaveSpawner : MonoBehaviour
{
    [Space(20)]
    [Tooltip("Attach The GameManager Prefab of the Scene")]
    public GameManager GameManager;

    [Tooltip("Activate to Start Spawning in the start of the Game")]
    public bool SpawnWave = false;
    public bool RandomSpawnOrder = false;

    [Space(20)]
    [Tooltip("Add Prefabs here with the Wave Script Added")]
    public List<Wave> Waves = new List<Wave>();
    [Tooltip("Add Various Enemy Prefabs to Spawn here")]
    public List<GameObject> EnemysToSpawn = new List<GameObject>();
    public List<Transform> EnemySpawnPoints = new List<Transform>();

    private Wave CurrentWave;

    private int SpawnOrderCounter;

    void Awake()
    {
        CurrentWave = Waves[0];
    }

    void Update()
    {
        CheckForNewWave();
        if (SpawnWave)
        {
            SpawnWave = false;
            StartCoroutine(SpawnTimer());
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(CurrentWave.Delay);
        Spawn();
    }

    IEnumerator WaveRepatTimer()
    {
        yield return new WaitForSeconds(CurrentWave.RepeatWaveAfter);
        CurrentWave.SpawnCounter = 0;
        Spawn();
    }

    private void Spawn()
    {
        
        
            if (CurrentWave.SpawnCounter < CurrentWave.Amount)
            {
            if (!GameManager.Pause)
            {
                CurrentWave.SpawnCounter++;
                Instantiate(GetRandomEnemy(), GetSpawnPoint(), Quaternion.identity);
            }
                

                StartCoroutine(SpawnTimer());
            }
            else
            {
                if (CurrentWave.RepeatWaveAfter != 0)
                    StartCoroutine(WaveRepatTimer());
            }
        
        
    }

    private void CheckForNewWave()
    {
        if (Waves.IndexOf(CurrentWave) != GameManager.CurrentStage)
        {
            CurrentWave = Waves[GameManager.CurrentStage - 1];
        }
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
