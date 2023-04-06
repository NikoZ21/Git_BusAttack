using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float explosionRadious = 1.5f;
    [SerializeField] Transform explosionCenter;
    private LayerMask bugLayer;
    [SerializeField] ParticleSystem explosionVFX;
    public float missileDamage = 100f;

    private void Start()
    {
        bugLayer = LayerMask.GetMask("Bugs");
        explosionCenter = GetComponentInChildren<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var vfx = Instantiate(explosionVFX, explosionCenter.position, Quaternion.identity);
        Destroy(vfx.gameObject, vfx.main.duration + vfx.main.startLifetime.constantMax);

        Collider2D[] bugs = Physics2D.OverlapCircleAll(explosionCenter.position, explosionRadious, bugLayer);
        foreach (var bug in bugs)
        {
            bug.GetComponent<Health>().TakeDamage(missileDamage);
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        if (explosionCenter == null) return;
        Gizmos.DrawWireSphere(explosionCenter.position, explosionRadious);
    }

}
