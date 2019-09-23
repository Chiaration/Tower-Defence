using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorSnap : MonoBehaviour
{

    [SerializeField] [Range(0, 10)] int gridSize = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gridSnap;
        gridSnap.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        gridSnap.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        
        transform.position = new Vector3(gridSnap.x, 0f , gridSnap.z);
    }
}
