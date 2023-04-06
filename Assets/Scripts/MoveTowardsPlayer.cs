using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject WinCanvas;

    void Update()
    {
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BusHealth>())
        {
            moveSpeed = 0;
            WinCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
