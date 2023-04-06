using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelOneSpawner : MonoBehaviour, ISpawner
{

    //General Settings
    bool isSpawning = true;


    [Header("June Bug")]
    [SerializeField] GameObject juneBug;
    [SerializeField] float jBugSpawnRate = 1f;
    [SerializeField] float minRate = 0.5f;
    [SerializeField] float maxRate = 1f;
    GameTimer timer;
    private float jBugSpawnTime;

    private void Start()
    {
        timer = FindObjectOfType<GameTimer>();
    }

    void Update()
    {
        if (isSpawning == false) return;
        SpawnJuneBugs();
    }

    void SpawnJuneBugs()
    {
        jBugSpawnRate = Random.Range(minRate, maxRate);
        if (Time.time < jBugSpawnTime) return;
        Instantiate(juneBug, transform.position, transform.rotation, transform);
        jBugSpawnTime = Time.time + jBugSpawnRate;
        if (timer.currentLevelTime <= 20)
        {
            minRate = 1f;
            maxRate = 1.5f;
        }
        else if (timer.currentLevelTime <= 40)
        {
            minRate = 0.8f;
            maxRate = 1.2f;
        }
        else if (timer.currentLevelTime <= 60)
        {
            minRate = 0.3f;
            maxRate = 0.5f;
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
