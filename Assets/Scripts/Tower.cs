using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;
    
    
    Transform targetEnemey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemey();
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

    private void SetTargetEnemey()
    {
        var sceneEnemies = FindObjectsOfType<Damage>();
        if (sceneEnemies.Length == 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (Damage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemey = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemyTransform)
    {
        float distanceFromEnemyA = Vector3.Distance(closestEnemy.position, gameObject.transform.position);
        float distanceFromEnemyB = Vector3.Distance(testEnemyTransform.position, gameObject.transform.position);

        if (distanceFromEnemyA < distanceFromEnemyB)
        {
            return closestEnemy;
        }
        else
        {
            return testEnemyTransform;
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
