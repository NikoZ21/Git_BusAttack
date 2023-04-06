using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeSpawner : MonoBehaviour, ISpawner
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
        ChangeSpawning();
    }
    private void ChangeSpawning()
    {
        if (timer.currentLevelTime <= 20)
        {
            isSpawningJBug = true;
            isSpawningCricket = false;
            isSpawningGrassHopper = false;
        }
        else if (timer.currentLevelTime <= 40)
        {
            isSpawningJBug = false;
            isSpawningCricket = true;
            isSpawningGrassHopper = false;
        }
        else if (timer.currentLevelTime <= 60)
        {
            isSpawningJBug = false;
            isSpawningCricket = false;
            isSpawningGrassHopper = true;
        }
        else if (timer.currentLevelTime <= 80)
        {
            isSpawningJBug = true;
            isSpawningCricket = true;
            cricketSpawnRate = 0.7f;
            minRate = 0.6f;
            maxRate = 0.8f;
            isSpawningGrassHopper = false;
        }
        else if (timer.currentLevelTime <= 100)
        {
            isSpawningCricket = false;
            isSpawningJBug = false;
            isSpawningGrassHopper = true;
            setToZero += SetPathIndex;
            setToZero?.Invoke();
            setToZero -= SetPathIndex;
        }
        else if (timer.currentLevelTime <= 120)
        {
            isSpawningGrassHopper = false;
            isSpawningJBug = true;
            isSpawningCricket = true;
            minRate = 0.6f;
            maxRate = 0.7f;
            cricketSpawnRate = 1f;
        }
    }
    void SpawnJuneBugs()
    {
        jBugSpawnRate = Random.Range(minRate, maxRate);
        if (Time.time < jBugSpawnTime || isSpawningJBug == false) return;
        Instantiate(juneBug, transform.position, transform.rotation, transform);
        jBugSpawnTime = Time.time + jBugSpawnRate;
    }

    void SpawnCrickets()
    {
        if (Time.time < cricketSpawnTime || isSpawningCricket == false) return;
        Instantiate(cricket, transform.position, transform.rotation, transform);
        cricketSpawnTime = Time.time + cricketSpawnRate;
    }
    void SpawnGrassHoppers()
    {
        if (isSpawningGrassHopper == false || pathIndex == paths.Length || Time.time < grassHopperSpawnTime) return;
        GameObject grassHopper = Instantiate(grassHoper, transform.position, transform.rotation, transform);
        grassHoper.GetComponent<GrassHopper>().path = paths[pathIndex];
        grassHopperSpawnTime = Time.time + grassHopperSpawnRate;
        pathIndex++;
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
