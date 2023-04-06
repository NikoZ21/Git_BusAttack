using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float damage = 50;
    [SerializeField] float moveSpeed = 30;
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 180f);
    }

    void Update()
    {
        transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bus = collision.gameObject.GetComponent<BusHealth>();
        if (bus)
        {
            bus.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
