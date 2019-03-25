using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Waypoint searchCentre;
    bool isCreatedPath = false;
    private List<Waypoint> path = new List<Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left
    };

    private bool isRunning = true;

    public List<Waypoint> GetPath()
    {
        if (!isCreatedPath)
        {
            LoadBlocks();
            BreadthFirstSearch();
            CreatePath();
            isCreatedPath = true;
        }
        return path;
    }
    private void CreatePath()
    {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while(previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCentre = queue.Dequeue();
            searchCentre.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();
        }
    }
    private void HaltIfEndFound()
    {
        if (endWaypoint == searchCentre)
        {
            isRunning = false;
        }
    }
    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }
        foreach(Vector2Int dir in directions)
        {
            Vector2Int neighborCoord = searchCentre.GetGridPos() + dir;
            if(grid.ContainsKey(neighborCoord))
            {
                QueueNewNeighbors(neighborCoord);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoord)
    {
        Waypoint neighbor = grid[neighborCoord];
        if (neighbor.isExplored || queue.Contains(neighbor))
        {
            
        }
        else
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCentre;
        }
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
