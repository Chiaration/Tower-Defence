using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyTransformParent;
    [SerializeField] Text scoreText;
    [SerializeField] int currentScore = 0;
    [SerializeField] int scoreIncrease = 10;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + currentScore;
    }
    
    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            currentScore = currentScore + scoreIncrease;
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyTransformParent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
