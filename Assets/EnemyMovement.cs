using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<GameObject> path;

    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject Path in path)
        {
            print(Path.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
