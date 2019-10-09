using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        print("My hitpoints: " + hitPoints);

        if (hitPoints <= 0)
        {
            killEnemy();
        }
    }

    private void killEnemy()
    {
        Destroy(gameObject);
    }
}
