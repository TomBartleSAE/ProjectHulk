using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float minDelay = 5, maxDelay = 10;
    private float timer;

    public GameObject[] objectsToSpawn;

    public void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Spawn();
                timer = 0;
            }
        }
    }

    public void Spawn()
    {
        Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], transform.position, transform.rotation);
        timer = Random.Range(minDelay, maxDelay);
    }
}
