using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rob
{
    public class RageMeter : MonoBehaviour
    {
        public Sprite[] rageSprites;
        private Sprite currentSprite;
        [SerializeField] public bool raged;
        private int counter;
        private Image rageImage;


        private void Awake()
        {
            counter = 0;
            rageImage = GetComponent<Image>();
        }

        private void Start()
        {
            StartCoroutine("SwitchSprite");
        }

        public void Update()
        {
            if (raged)
            {
                StopCoroutine("SwitchSprite");
                currentSprite = rageSprites[counter];
                rageImage.sprite = currentSprite;
                counter++;
                
                if (counter >= rageSprites.Length)
                {
                    raged = false;
                    counter = rageSprites.Length - 1;
                }
            }
        }

        public IEnumerator SwitchSprite()
        {
            currentSprite = rageSprites[counter];
            rageImage.sprite = currentSprite;

            if (counter < rageSprites.Length)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }

            yield return new WaitForSeconds(1f);
            StartCoroutine("SwitchSprite");
        }
    }
}