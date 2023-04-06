using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourSpawner : MonoBehaviour, ISpawner
{
    //General Settings
    bool isSpawning = true;
    GameTimer timer;

    [Header("June Bug")]
    [SerializeField] GameObject juneBug;
    [SerializeField] float jBugSpawnRate = 1f;
    [SerializeField] float minRate = 0.5f;
    [SerializeField] float maxRate = 1f;
    private float jBugSpawnTime;
    private bool isSpawningJBug = true;


    [Header("Cricket")]
    [SerializeField] GameObject cricket;
    [SerializeField] float cricketSpawnRate = 1f;
    private float cricketSpawnTime;
    [SerializeField] private bool isSpawningCricket = false;

    [Header("Grass Hoper")]
    [SerializeField] GameObject grassHoper;
    [SerializeField] private bool isSpawningGrassHopper = false;
    [SerializeField] GameObject[] paths;
    [SerializeField] float grassHopperSpawnRate = 0.5f;
    private int pathIndex = 0;
    private float grassHopperSpawnTime;
    delegate void SetToZero();
    event SetToZero setToZero;

    [Header("June Bug")]
    [SerializeField] GameObject hugeFly;
    [SerializeField] float hugeFlySpawnRate = 1f;
    private float hugeFlySpawnTime;
    private bool isSpawningHugeFly = false;

    private void Start()
    {
        timer = FindObjectOfType<GameTimer>();
    }

    void Update()
    {
        if (isSpawning == false) return;
        SpawnJuneBugs();
        SpawnCrickets();
        SpawnGrassHoppers();
        SpawnHugeFlies();
        ChangeSpawning();
    }

    private void ChangeSpawning()
    {
        if (timer.currentLevelTime <= 30)
        {
            isSpawningJBug = true;
            isSpawningCricket = false;
            isSpawningGrassHopper = true;
            isSpawningHugeFly = false;
        }
        else if (timer.currentLevelTime <= 60)
        {
            isSpawningJBug = true;
            isSpawningCricket = true;
            cricketSpawnRate = 0.7f;
            minRate = 0.5f;
            maxRate = 0.7f;
            isSpawningGrassHopper = false;
            isSpawningHugeFly = false;
        }
        else if (timer.currentLevelTime <= 90)
        {
            isSpawningJBug = false;
            isSpawningCricket = false;
            isSpawningGrassHopper = false;
            isSpawningHugeFly = true;
            hugeFlySpawnRate = 1.5f;
        }
        else if (timer.currentLevelTime <= 120)
        {
            isSpawningJBug = true;
            isSpawningCricket = false;
            isSpawningHugeFly = false;
            minRate = 0.4f;
            maxRate = 0.6f;
            isSpawningGrassHopper = true;
            grassHopperSpawnRate = 4f;
            setToZero += SetPathIndex;
            setToZero?.Invoke();
            setToZero -= SetPathIndex;
        }
        else if (timer.currentLevelTime <= 150)
        {
            isSpawningCricket = true;
            isSpawningJBug = false;
            isSpawningGrassHopper = false;
            isSpawningHugeFly = true;
            hugeFlySpawnRate = 1.3f;
            cricketSpawnRate = 1f;
        }
    }
    void SpawnJuneBugs()
    {
        jBugSpawnRate = Random.Range(minRate, maxRate);
        if (Time.time < jBugSpawnTime || isSpawningJBug == false) return;
        Instantiate(juneBug, transform.position, transform.rotation, transform);
        jBugSpawnTime = Time.time + jBugSpawnRate;
        if (timer.currentLevelTime > 20)
        {
            minRate = 1f;
            maxRate = 1.5f;
            isSpawningCricket = true;
        }
    }

    void SpawnCrickets()
    {
        if (Time.time < cricketSpawnTime || isSpawningCricket == false) return;
        Instantiate(cricket, transform.position, transform.rotation, transform);
        cricketSpawnTime = Time.time + cricketSpawnRate;
        if (timer.currentLevelTime > 25)
        {
            cricketSpawnRate = 0.7f;
            if (timer.currentLevelTime >= 35)
            {
                isSpawningCricket = false;
                isSpawningJBug = true;
                isSpawningGrassHopper = true;
            }
        }
    }
    void SpawnGrassHoppers()
    {
        if (isSpawningGrassHopper == false || pathIndex == paths.Length || Time.time < grassHopperSpawnTime) return;
        GameObject grassHopper = Instantiate(grassHoper, transform.position, transform.rotation, transform);
        grassHoper.GetComponent<GrassHopper>().path = paths[pathIndex];
        grassHopperSpawnTime = Time.time + grassHopperSpawnRate;
        pathIndex++;
    }

    void SpawnHugeFlies()
    {
        if (isSpawningHugeFly == false || Time.time < hugeFlySpawnTime) return;
        Instantiate(hugeFly, transform.position, transform.rotation, transform);
        hugeFlySpawnTime = Time.time + hugeFlySpawnRate;
    }
    public void SetPathIndex()
    {
        pathIndex = 0;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
