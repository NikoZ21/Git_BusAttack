using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoSpawner : MonoBehaviour, ISpawner
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

    private void Start()
    {
        timer = FindObjectOfType<GameTimer>();
    }

    void Update()
    {
        if (isSpawning == false) return;
        SpawnJuneBugs();
        SpawnCrickets();
        ChangeSpawning();
    }

    private void ChangeSpawning()
    {
        if (timer.currentLevelTime <=20)
        {
            isSpawningJBug = true;
            isSpawningCricket = false;
        }
        else if(timer.currentLevelTime <=40)
        {
            isSpawningJBug = false;
            isSpawningCricket = true;
        }
        else if (timer.currentLevelTime <= 60)
        {
            isSpawningJBug = true;
            isSpawningCricket = false;
            minRate = 0.5f;
            maxRate = 0.8f;
        }
        else if(timer.currentLevelTime <= 80)
        {
            isSpawningJBug = false;
            isSpawningCricket = true;
            cricketSpawnRate = 0.7f;
        }
        else if(timer.currentLevelTime <=100)
        {
            isSpawningCricket = true;
            isSpawningJBug = true;
            minRate = 1;
            maxRate = 1.2f;
            cricketSpawnRate = 1;
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

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
