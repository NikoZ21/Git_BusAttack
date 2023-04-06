using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuneBug : MonoBehaviour
{
    [SerializeField] float moveSpeed = -3f;
    [SerializeField] float damage = 50;
    private void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-2.86f, 2.86f), 0, 0);
        transform.localEulerAngles = new Vector3(0, 0, 180);
    }
    void Update()
    {
        transform.position += new Vector3(0f, moveSpeed, 0f) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bus = collision.GetComponent<BusHealth>();
        if(bus)
        {
            bus.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
