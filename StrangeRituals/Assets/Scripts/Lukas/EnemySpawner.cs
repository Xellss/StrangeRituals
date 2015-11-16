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
    public GameObject[] EnemysToSpawn_1;
    public int Count_1_Normal;
    public int Count_1_Speed;
    public int Count_1_Tank;
    public float SpawnDelay_1;
    public bool SpawnRandomOrder_1;

    [Space(20)]
    public GameObject[] EnemysToSpawn_2;
    public int Count_2_Normal;
    public int Count_2_Speed;
    public int Count_2_Tank;
    public float SpawnDelay_2;
    public bool SpawnRandomOrder_2;

    [Space(20)]
    public GameObject[] EnemysToSpawn_3;
    public int Count_3_Normal;
    public int Count_3_Speed;
    public int Count_3_Tank;
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
        {
            StartNewWave(EnemysToSpawn_1[2], Count_1_Tank, SpawnDelay_1, SpawnRandomOrder_1);
            StartNewWave(EnemysToSpawn_1[0], Count_1_Normal, SpawnDelay_1, SpawnRandomOrder_1);
            StartNewWave(EnemysToSpawn_1[1], Count_1_Speed, SpawnDelay_1, SpawnRandomOrder_1);
            GameManagerObject.Level_1 = false;
        }

        if (GameManagerObject.Level_2)
        {
            StartNewWave(EnemysToSpawn_2[0], Count_2_Normal, SpawnDelay_2, SpawnRandomOrder_2);
            StartNewWave(EnemysToSpawn_2[1], Count_2_Speed, SpawnDelay_2, SpawnRandomOrder_2);
            StartNewWave(EnemysToSpawn_2[2], Count_2_Tank, SpawnDelay_2, SpawnRandomOrder_2);
            GameManagerObject.Level_2 = false;
        }

        if (GameManagerObject.Level_3)
        {
            StartNewWave(EnemysToSpawn_3[0], Count_3_Normal, SpawnDelay_3, SpawnRandomOrder_3);
            StartNewWave(EnemysToSpawn_3[1], Count_3_Speed, SpawnDelay_3, SpawnRandomOrder_3);
            StartNewWave(EnemysToSpawn_3[2], Count_3_Tank, SpawnDelay_3, SpawnRandomOrder_3);
            GameManagerObject.Level_3 = false;
        }
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
        if (!GameManagerObject.Pause)
        {
            spawnCount++;
            Instantiate(GameobjectToSpawn, ChoosePosition(), Quaternion.identity);
        }
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
