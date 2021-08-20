using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class PlayerJumping : MonoBehaviour
    {
        private Rigidbody2D rb;
        public float jumpForce = 1f;
        public LayerMask groundLayer;

        public float groundDistance = 0.5f;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            if (CheckGround())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        private bool CheckGround()
        {
            return Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        }
    }
}