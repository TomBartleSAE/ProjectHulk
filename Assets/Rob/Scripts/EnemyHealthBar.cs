using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tom;
using UnityEngine.UI;


namespace Rob
{
    public class EnemyHealthBar : MonoBehaviour
    {
        public Sprite[] enemySprite;
        private Sprite currentEnemySprite;
        private Image enemyImage;
        private int counter;


        private void Awake()
        {
            counter = 0;
            enemyImage = GetComponent<Image>();
        }

        private void Start()
        {
            currentEnemySprite = enemySprite[counter];
            enemyImage.sprite = currentEnemySprite;
        }


        public void EnemyKilled()
        {
            counter++;
            currentEnemySprite = enemySprite[counter];
            enemyImage.sprite = currentEnemySprite;
            
            if (counter > enemySprite.Length)
            {
                //do stuff
            }
        }
    }
}