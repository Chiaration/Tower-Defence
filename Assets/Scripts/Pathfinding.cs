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

    private List<Waypoints> path = new List<Waypoints>();

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoints> getPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            BFS();
            CreatePath();
        }
        return path;
    }

    private void CreatePath()
    {
        path.Add(end);
        end.isPlaceable = false;
        Waypoints previous = end.exploredFrom;

        while (previous != start)
        {
            path.Add(previous);
            previous.isPlaceable = false;
            previous = previous.exploredFrom;
        }
        
        path.Add(start);
        start.isPlaceable = false;

        path.Reverse();
    }

    private void BFS()
    {
        queue.Enqueue(start);

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
            try
            {
                if (!grid[explorationCoords].isExplored && !queue.Contains(grid[explorationCoords]))
                {
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
    }
}
