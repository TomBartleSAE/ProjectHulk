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
         GameObject.FindObjectOfType<Building>().GetComponent<Health>().OnDamageEvent += CityTakeDamage;
      }

      private void OnDisable()
      {
         GameObject.FindObjectOfType<Building>().GetComponent<Health>().OnDamageEvent -= CityTakeDamage;
      }

      public void Update()
      {
         if (Input.GetKeyDown(KeyCode.M))
         {
            CityTakeDamage();
         }
      }


      public void CityTakeDamage()
      {
         
         counter++;
         currentCitySprite = cityHealth[counter];
         cityImage.sprite = currentCitySprite;
      }
   }
}
