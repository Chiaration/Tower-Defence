using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSCodeEditor;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoints))]

public class CubeEditor : MonoBehaviour
{

    TextMesh textMeshCoords;
    Waypoints waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoints>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(waypoint.GetGridSnap().x, 0f, waypoint.GetGridSnap().y);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        textMeshCoords = GetComponentInChildren<TextMesh>();
        string coordsText = waypoint.GetGridSnap().x / gridSize + "," + waypoint.GetGridSnap().y / gridSize;
        textMeshCoords.text = coordsText;
        gameObject.name = coordsText;
    }
}
