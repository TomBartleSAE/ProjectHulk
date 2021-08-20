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
        
        
        
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            enragedState = FindObjectOfType<EnragedState>();
        }

        public void OnEnable()
        {
            FindObjectOfType<Health>().OnDamageEvent += DamageTaken;
        }

        public void OnDisable()
        {
            FindObjectOfType<Health>().OnDamageEvent -= DamageTaken;
        }


        public void DamageTaken()
        {
            currentHealth -= 1;
            if (currentHealth <= 0);
            {
                enragedState.StartRage();
                currentHealth = maxHealth;
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
