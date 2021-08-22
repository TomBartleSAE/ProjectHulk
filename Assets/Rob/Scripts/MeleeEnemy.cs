using System;
using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float stopDistance;

    private float attackTime;

    public float meleeAttackSpeed;

    private Animator anim;

    public override void Start()
    {
        base.Start();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                anim.SetFloat("Movement", 1);
            }
            else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(MeleeAttack());
                    attackTime = Time.time + timeBetweenAttacks;
                }

                anim.SetFloat("Movement", 0);
            }
            
            if (player.position.x - transform.position.x > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }

            if (player.position.x - transform.position.x < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            }
        }
    }

    IEnumerator MeleeAttack()
    {
        player.GetComponent<Health>().TakeDamage();
        anim.SetTrigger("Attack");

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * meleeAttackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }

    private void OnEnable()
    {
        GetComponent<Health>().OnDamageEvent += Die;
    }

    private void OnDisable()
    {
        GetComponent<Health>().OnDamageEvent -= Die;
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        Destroy(gameObject, 5);
    }
}