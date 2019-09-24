using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    const int gridSize = 5;

    Vector2Int gridSnap;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2 GetGridSnap()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
