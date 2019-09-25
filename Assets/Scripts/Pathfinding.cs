using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Waypoints start;
    [SerializeField] Waypoints end;
    
    
    Dictionary<Vector2Int, Waypoints> grid = new Dictionary<Vector2Int, Waypoints>();
    
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypointss = FindObjectsOfType<Waypoints>();
        foreach (Waypoints waypoints in waypointss)
        {
            bool isOverlapping = grid.ContainsKey(waypoints.GetGridSnap());
            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping Block " + waypoints);
            }
            else
            {
                grid.Add(waypoints.GetGridSnap(), waypoints);
                if (waypoints.GetGridSnap() == start.GetGridSnap()) 
                {
                    waypoints.SetTopColour(Color.green);
                }
                else if (waypoints.GetGridSnap() == end.GetGridSnap())
                {
                    waypoints.SetTopColour(Color.red);
                }
                else
                {
                    waypoints.SetTopColour(Color.magenta);
                }
            }
        }
        print(grid.Count);
    }
}
