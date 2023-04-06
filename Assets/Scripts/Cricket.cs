using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cricket : MonoBehaviour
{
    [SerializeField] float jumpDistance = 20;
    [SerializeField] float cricketDamage = 50;
    [SerializeField] float waitTimerValue = 0.5f;
    float waitTimer;

    Vector3 targetPosition;
    float jumpY = 8;

    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, 180);
        targetPosition = new Vector3(Random.Range(-3.5f, 3.5f), jumpY);
        transform.position = targetPosition;
    }

    void Update()
    {
        if (transform.position == targetPosition && jumpY > 0)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer > 0) return;

            jumpY -= 3.5f;
            targetPosition = new Vector3(Random.Range(-3.5f, 3.5f), jumpY);
            waitTimer = waitTimerValue;
        }
        else if (transform.position == targetPosition && jumpY <= 0)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer > 0) return;
            var playerPosition = FindObjectOfType<BusMovement>().transform.position;
            if (playerPosition == null) Debug.Log("Player is dead");
            else targetPosition = playerPosition;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, jumpDistance * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var busHealth = collision.gameObject.GetComponent<BusHealth>();
        if (busHealth)
        {
            busHealth.TakeDamage(cricketDamage);
            Destroy(gameObject);
        }
    }
}
