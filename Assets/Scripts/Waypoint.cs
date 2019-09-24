using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSCodeEditor;

[ExecuteInEditMode]
[SelectionBase]

public class Waypoint : MonoBehaviour
{

    [SerializeField] [Range(0, 10)] int gridSize = 1;

    private TextMesh textMeshCoords;


    // Start is called before the first frame update
    void Start()
    {
        textMeshCoords = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gridSnap;
        gridSnap.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        gridSnap.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        
        transform.position = new Vector3(gridSnap.x, 0f , gridSnap.z);

        string coordsText = gridSnap.x / gridSize + "," + gridSnap.z / gridSize;
        textMeshCoords.text = coordsText;
        gameObject.name = coordsText;
    }
}
