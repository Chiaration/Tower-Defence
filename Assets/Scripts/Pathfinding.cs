using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Waypoints start;
    [SerializeField] Waypoints end;
    
    
    Dictionary<Vector2Int, Waypoints> grid = new Dictionary<Vector2Int, Waypoints>();
    Queue<Waypoints> queue = new Queue<Waypoints>();
    private bool isRunning = true;

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(start);

        print(queue.Peek());

        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
        }
    }

    private void HaltIfEndFound(Waypoints searchCenter)
    {
        if (searchCenter == end)
        {
            isRunning = false;
            print("Ending");
        }
    }

    private void ExploreNeighbours(Waypoints from)
    {
        if (!isRunning)
        {
            return; }
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoords = from.GetGridSnap() + direction;
            print("Exploring " + explorationCoords);
            try
            {
                if (!grid[explorationCoords].isExplored)
                {
                    grid[explorationCoords].SetTopColour(Color.blue);
                    queue.Enqueue(grid[explorationCoords]);
                }
            }
            catch (Exception e)
            {
                //do nothing
            }
        }
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
