using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tom;


namespace Rob
{
    public class PlayerHealth : MonoBehaviour
    {
        public int currentHealth;
        public int maxHealth;
        private EnragedState enragedState;
        private HealthBar healthBar;
        private RageMeter rageMeter;


        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            enragedState = FindObjectOfType<EnragedState>();
            healthBar = FindObjectOfType<HealthBar>();
            rageMeter = FindObjectOfType<RageMeter>();
        }

        public void OnEnable()
        {
            GetComponent<Health>().OnDamageEvent += DamageTaken;
        }

        public void OnDisable()
        {
            GetComponent<Health>().OnDamageEvent -= DamageTaken;
        }


        public void DamageTaken()
        {
            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                if (enragedState.timer <= 0)
                {
                    enragedState.StartRage();
                    rageMeter.raged = true;
                }

                currentHealth = maxHealth;
                
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}