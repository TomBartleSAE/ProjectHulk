using System;
using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer currentSprite;
    private Health health;
    private int currentHealth;
    public event Action OnBuildingDamage;

    public void DamageBuilding()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            currentSprite.sprite = sprites[currentHealth];
            OnBuildingDamage?.Invoke();
        }
    }

    private void OnEnable()
    {
        health.OnDamageEvent += DamageBuilding;
    }

    private void OnDisable()
    {
        health.OnDamageEvent -= DamageBuilding;
    }
}
