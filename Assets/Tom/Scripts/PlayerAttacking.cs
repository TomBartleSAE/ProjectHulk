using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class PlayerAttacking : MonoBehaviour
    {
        public float attackDelay;
        private float attackTimer;
        public Transform attackPoint;
        public float attackRadius = 0.5f;
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }

            if (Input.GetButtonDown("Fire1") && attackTimer <= 0)
            {
                Attack();
            }
        }

        void Attack()
        {
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

            if (hitObjects != null)
            {
                foreach (Collider2D obj in hitObjects)
                {
                    obj.GetComponent<Health>()?.TakeDamage();
                }
            }
            
            anim.SetTrigger("Attack");

            attackTimer = attackDelay;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }
}