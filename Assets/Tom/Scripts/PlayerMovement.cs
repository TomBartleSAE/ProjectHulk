using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Animator anim;
        public float speed = 5f;
        private float moveDirection;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        
        public void Move(float horizontal)
        {
            anim.SetFloat("Movement", Mathf.Abs(horizontal));
            anim.SetFloat("yVelocity", rb.velocity.y);

            if (horizontal > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }

            if (horizontal < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            }

            moveDirection = horizontal;
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
        }
    }
}