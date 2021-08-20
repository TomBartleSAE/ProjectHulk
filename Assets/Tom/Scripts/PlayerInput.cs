using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement movement;
        private PlayerJumping jumping;
        private PlayerAttacking attacking;

        private void Start()
        {
            movement = GetComponent<PlayerMovement>();
            jumping = GetComponent<PlayerJumping>();
            attacking = GetComponent<PlayerAttacking>();
        }

        private void Update()
        {
            movement.Move(Input.GetAxisRaw("Horizontal"));

            if (Input.GetButtonDown("Jump"))
            {
                jumping.Jump();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                attacking.Attack();
            }
        }
    }
}