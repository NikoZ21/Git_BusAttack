using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BusMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float maxSpeed = 7f;
    [SerializeField] float lineaDrag = 5f;
    Rigidbody2D rb;
    Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SetDefaultShootingSettings();
        }
        else
        {
            SetShootingSettings();
        }
    }

    private void SetShootingSettings()
    {
        maxSpeed = UpgradePlayerPrefs.GetBusMaxMoveSpeed();
    }

    private void SetDefaultShootingSettings()
    {
        UpgradePlayerPrefs.SetBusMaxMoveSpeed(7f);
        maxSpeed = UpgradePlayerPrefs.GetBusMaxMoveSpeed();
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), 0f);
    }

    private void FixedUpdate()
    {
        var bus = FindObjectOfType<BusHealth>();
        if (bus.isAlive == false) return;

        MoveBus(direction.x);
        ModifyPhysics();
    }

    private void MoveBus(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }
    void ModifyPhysics()
    {
        bool changingDirections = (direction.x > 0f && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);
        if (changingDirections)
        {
            rb.drag = lineaDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
}
