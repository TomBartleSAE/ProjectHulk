using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 1f;

    public float groundDistance = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && CheckGround())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool CheckGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundDistance);
    }
}
