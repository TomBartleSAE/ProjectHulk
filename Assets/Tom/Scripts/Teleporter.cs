using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class Teleporter : MonoBehaviour
    {
        public Transform teleportLocation;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.position = teleportLocation.position;
            }
        }
    }
}