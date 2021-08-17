using System;
using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;

public class EnragedState : MonoBehaviour
{
    public float rageTime = 5f;
    private float timer;

    private PlayerMovement movement;
    private PlayerAttacking attacking;
    private PlayerJumping jumping;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        attacking = GetComponent<PlayerAttacking>();
        jumping = GetComponent<PlayerJumping>();
    }

    public void StartRage()
    {
        movement.enabled = false;
        attacking.enabled = false;
        jumping.enabled = false;
    }

    public void StopRage()
    {
        movement.enabled = true;
        attacking.enabled = true;
        jumping.enabled = true;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            
            
        }

        if (timer < 0)
        {
            timer = 0;
        }
    }
}
