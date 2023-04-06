using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHeath = 50;
    [SerializeField] ParticleSystem deathVFX;
    float currentHealth;

    void Start()
    {
        currentHealth = maxHeath;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(vfx.gameObject, vfx.main.duration + vfx.main.startLifetime.constantMax);
    }
}
