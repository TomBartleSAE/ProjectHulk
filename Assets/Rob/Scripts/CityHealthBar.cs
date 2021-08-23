using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tom;

namespace Rob
{
    public class CityHealthBar : MonoBehaviour
    {
        public Sprite[] cityHealth;
        private Sprite currentCitySprite;
        private Image cityImage;
        private int counter;
        


        private void Awake()
        {
            counter = 0;
            cityImage = GetComponent<Image>();
        }

        private void Start()
        {
            currentCitySprite = cityHealth[counter];
            cityImage.sprite = currentCitySprite;
        }

        private void OnEnable()
        {
            Building[] buildings = FindObjectsOfType<Building>();
            foreach (Building building in buildings)
            {
                building.GetComponent<Health>().OnDamageEvent += CityTakeDamage;
            }
        }

        private void OnDisable()
        {
            Building[] buildings = FindObjectsOfType<Building>();
            foreach (Building building in buildings)
            {
                building.GetComponent<Health>().OnDamageEvent -= CityTakeDamage;
            }
        }


        public void CityTakeDamage()
        {
            counter++;
            currentCitySprite = cityHealth[counter];
            cityImage.sprite = currentCitySprite;
            if (counter >= cityHealth.Length - 1)
            {
                FindObjectOfType<PanelScreen>().LostGame();
            }
        }
    }
}