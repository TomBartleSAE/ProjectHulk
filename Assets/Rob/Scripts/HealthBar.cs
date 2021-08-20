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
        public Slider healthSlider;


        public void SetMaxHealth(int health)
        {
            healthSlider.value = health;
            healthSlider.value = health;
        }

        public void SetHealth(int health)
        {
            healthSlider.value = health;
        }





        
    }
}
