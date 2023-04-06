using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    Rigidbody2D rb;
    float resetPoint;
    [SerializeField] float scrollspeed = -2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, scrollspeed);
        resetPoint = transform.position.y - 19.2f;
    }

    void Update()
    {
        if (transform.position.y < resetPoint)
        {
            Vector3 resetPosition = new Vector3(0, 19.2f);
            transform.position = transform.position + resetPosition;
        }
    }
}
