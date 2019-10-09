using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemey;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemey)
        {
            objectToPan.LookAt(targetEnemey);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void FireAtEnemy()
    {
        float DistanceToEnemy = Vector3.Distance(targetEnemey.transform.position, gameObject.transform.position);
        if (DistanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
