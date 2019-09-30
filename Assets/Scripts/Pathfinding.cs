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
    
    Waypoints searchCenter;

    public List<Waypoints> path;

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
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours();
        }
    }

    private void HaltIfEndFound( )
    {
        if (searchCenter == end)
        {
            isRunning = false;
            print("Ending");
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning)
        {
            return; }
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoords = searchCenter.GetGridSnap() + direction;
            print("Exploring " + explorationCoords);
            try
            {
                if (!grid[explorationCoords].isExplored && !queue.Contains(grid[explorationCoords]))
                {
                    grid[explorationCoords].SetTopColour(Color.blue);
                    queue.Enqueue(grid[explorationCoords]);
                    grid[explorationCoords].exploredFrom = searchCenter;
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
