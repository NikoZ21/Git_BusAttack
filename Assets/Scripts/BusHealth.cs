using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusHealth : MonoBehaviour
{
    [SerializeField] float maxHeath = 50;
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject gunRight;
    [SerializeField] GameObject gunLeft;
    [SerializeField] GameObject missile;
    float currentHealth;
    Animator animator;
    public bool isAlive = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHeath;
        healthBar.SetMaxHealth(maxHeath);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        isAlive = false;
        Destroy(gunRight);
        Destroy(gunLeft);
        Destroy(missile);
        animator.SetTrigger("Explode");
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameSession>().DisplayGameOver();
        Destroy(gameObject);
    }
}
