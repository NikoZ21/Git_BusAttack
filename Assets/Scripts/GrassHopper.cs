using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassHopper : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] float moveSpeed = 10f;
    public GameObject path;
    private Transform[] wayPoints;
    private int waypointIndex = 0;

    [Header("Shoot Settings")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float minSpawnRate = 0.4f;
    [SerializeField] float maxSpawnRate = 0.8f;
    private float bulletspawnRate;
    private float timeToShoot;


    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-2.86f, 2.86f), 0, 0);
        transform.localEulerAngles = new Vector3(0, 0, 180);
        wayPoints = path.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        Shoot();
    }

    private void Move()
    {
        var targetPosition = wayPoints[waypointIndex].position;
        if (transform.position == targetPosition)
        {
            if (waypointIndex == wayPoints.Length - 1) return;
            waypointIndex++;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        if (Time.time > timeToShoot)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletspawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            timeToShoot = Time.time + bulletspawnRate;
        }
    }
}
