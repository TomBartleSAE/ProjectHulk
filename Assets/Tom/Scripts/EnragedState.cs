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
    private PlayerInput input;

    private Transform target;

    public LayerMask targetLayer;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        attacking = GetComponent<PlayerAttacking>();
        jumping = GetComponent<PlayerJumping>();
        input = GetComponent<PlayerInput>();
    }

    public void StartRage()
    {
        input.enabled = false;
        timer = rageTime;
    }

    public void StopRage()
    {
        input.enabled = true;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (target == null)
            {
                FindTarget();
            }

            float distance = target.position.x - transform.position.x;
            if (Mathf.Abs(distance) < 0.5f)
            {
                attacking.Attack();
                movement.Move(0);
            }
            else if (distance > 0)
            {
                movement.Move(1);
            }
            else if (distance < 0)
            {
                movement.Move(-1);    
            }
        }

        if (timer < 0)
        {
            timer = 0;
            StopRage();
        }
    }

    public void FindTarget()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, 100f, targetLayer);

        float bestDistance = Mathf.Infinity;
        foreach (Collider2D obj in objects)
        {
            float newDistance = Vector2.Distance(transform.position, obj.transform.position);
            if (newDistance < bestDistance)
            {
                target = obj.transform;
                bestDistance = newDistance;
            }
        }
    }
}
