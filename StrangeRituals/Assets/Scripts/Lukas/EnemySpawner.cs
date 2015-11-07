using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject GameobjectToSpawn;

    private GameManager GameManagerObject;

    public List<Transform> SpawnPoints = new List<Transform>();

    public int Count;

    [Range(0, 10)]
    public float SpawnDelay;
    public bool RandomOrder = false;
    public bool StartSpawning = false;

    [Space(20)]
    public GameObject EnemysToSpawn_1;
    public int Count_1;
    public float SpawnDelay_1;
    public bool SpawnRandomOrder_1;

    [Space(20)]
    public GameObject EnemysToSpawn_2;
    public int Count_2;
    public float SpawnDelay_2;
    public bool SpawnRandomOrder_2;

    [Space(20)]
    public GameObject EnemysToSpawn_3;
    public int Count_3;
    public float SpawnDelay_3;
    public bool SpawnRandomOrder_3;

    private int spawnIndex = 0;
    private int spawnCount = 0;

    void Start()
    {
        GameObject GamemanagerGameObject = GameObject.Find("Gamemanager");
        GameManagerObject = GamemanagerGameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        CheckForWaves();

        if (StartSpawning)
        {
            StartCoroutine(SpawnTimer());
            StartSpawning = false;
        }
    }

    private void CheckForWaves()
    {
        if (GameManagerObject.Level_1)
            StartNewWave(EnemysToSpawn_1, Count_1, SpawnDelay_1, SpawnRandomOrder_1);

        if (GameManagerObject.Level_2)
            StartNewWave(EnemysToSpawn_2, Count_2, SpawnDelay_2, SpawnRandomOrder_2);

        if (GameManagerObject.Level_3)
            StartNewWave(EnemysToSpawn_3, Count_3, SpawnDelay_3, SpawnRandomOrder_3);
    }

    private void StartNewWave(GameObject toSpawn ,int count, float spawnDelay, bool spawnRandomOrder)
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
