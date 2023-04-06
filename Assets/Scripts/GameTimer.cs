using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] float levelDuration = 20f;
    [SerializeField] float houseDelay = 5f;
    [SerializeField] TimerBar timer;
    [SerializeField] GameObject farmHouse;
    public float currentLevelTime = 0;
    void Start()
    {
        timer.SetMaxTime(levelDuration);
    }

    void Update()
    {
        currentLevelTime += Time.deltaTime;
        timer.SetCurrentTime(currentLevelTime);
        var ispawner = GetComponent<ISpawner>();
        if (currentLevelTime >= levelDuration)
        {
            ispawner.StopSpawning();
            if (currentLevelTime! >= levelDuration + houseDelay)
            {
                farmHouse.SetActive(true);
            }
        }
    }
}
