using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
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
