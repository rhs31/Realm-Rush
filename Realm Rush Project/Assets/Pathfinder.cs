using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        // Remember that these are mapped to (x, z) not (x, y) in this game.
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    }; 
    // Use this for initialization
	void Start () {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbors();
	}

    private void ExploreNeighbors()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            print("Exploring " + explorationCoordinates);
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                // do nothing
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>(); // this is an array of waypoints
        foreach(Waypoint waypoint in waypoints)
        {
            // overlapping blocks?
            var gridPos = waypoint.GetGridPos();
            if(grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block" + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
            
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
