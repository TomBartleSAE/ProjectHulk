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
        public GameObject hitEffect;

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
        }

        public void Attack()
        {
            if (attackTimer <= 0)
            {
                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

                if (hitObjects != null)
                {
                    GameObject newEffect = Instantiate(hitEffect, attackPoint.position, Quaternion.identity);
                    Destroy(newEffect, 1f);
                    
                    foreach (Collider2D obj in hitObjects)
                    {
                        obj.GetComponent<Health>()?.TakeDamage();
                    }
                }
            
                anim.SetTrigger("Attack");

                attackTimer = attackDelay;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }
}