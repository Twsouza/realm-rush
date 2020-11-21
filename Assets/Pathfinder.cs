using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
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
        ColorStartAndEnd();
        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();

            if (searchCenter == endWaypoint)
            {
                print("End Waypoint found!");
                break;
            }

            ExploreNeighbours(searchCenter);
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int exploreCoord = from.GetGridPos() + direction;
            try
            {
                Waypoint neighbour = grid[exploreCoord];
                neighbour.SetTopColor(Color.magenta); // todo move later

                if (!neighbour.isExplored)
                {
                    queue.Enqueue(neighbour);
                    neighbour.isExplored = true;
                    print(neighbour + " queued");
                }
            }
            catch
            {

            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.cyan);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());

            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
        print(grid.Count);
    }

}
