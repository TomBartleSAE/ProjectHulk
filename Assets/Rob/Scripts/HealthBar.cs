using System;
using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;
using UnityEngine.UI;

namespace Rob
{
    public class HealthBar : MonoBehaviour
    {
        private Animator anim;


        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                anim.SetTrigger("HealthUI");
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                anim.SetTrigger("HealthRefill");
            }
        }

        public void OnEnable()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().OnDamageEvent += DamageTaken;
        }

        public void OnDisable()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().OnDamageEvent -= DamageTaken;
        }


        public void DamageTaken()
        {
            anim.SetTrigger("HealthUI");
        }
    }
}