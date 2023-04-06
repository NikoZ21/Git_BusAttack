using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() || collision.GetComponent<Missile>())
        {
            Destroy(collision.gameObject);
        }
    }
}
