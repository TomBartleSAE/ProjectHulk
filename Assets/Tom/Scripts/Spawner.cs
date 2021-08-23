using System;
using System.Collections;
using System.Collections.Generic;
using Rob;
using Tom;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float minDelay = 5, maxDelay = 10;
    private float timer;

    public GameObject[] objectsToSpawn;
    private EnemyHealthBar enemyHealth;

    public void Start()
    {
        enemyHealth = FindObjectOfType<EnemyHealthBar>();
        timer = Random.Range(minDelay, maxDelay);
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        GameObject newEnemy = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length - 1)], transform.position, transform.rotation);
        newEnemy.GetComponent<Health>().OnDamageEvent += enemyHealth.EnemyKilled;
        timer = Random.Range(minDelay, maxDelay);
    }
}
