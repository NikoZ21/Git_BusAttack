using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float damage = 25;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Health>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
