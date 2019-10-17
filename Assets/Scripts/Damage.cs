using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem HitParticlePrefab;
    [SerializeField] private ParticleSystem DeathParticlePrefab;

    [SerializeField] Waypoints endWayPoint;

    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip deathSound;
    
    
    


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
        GetComponent<AudioSource>().PlayOneShot(damageSound);
        hitPoints = hitPoints - 1;
        HitParticlePrefab.Play();

        if (hitPoints <= 0)
        {
            killEnemy();
        }
    }

    private void killEnemy()
    {
        var deathParticle = Instantiate(DeathParticlePrefab, transform.position, Quaternion.identity);
        deathParticle.Play();
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        
        float destoryDelay = deathParticle.main.duration;
        Destroy(deathParticle.gameObject, destoryDelay);
        Destroy(gameObject);
    }
    
    
}
