using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeFlies : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] float moveSpeed = 10f;
    Vector3 targetPosition;

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
        targetPosition = transform.position;
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
        if (transform.position == targetPosition)
        {
            targetPosition = new Vector3(Random.Range(-4.88f, 4.88f), Random.Range(-1, 10));
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
