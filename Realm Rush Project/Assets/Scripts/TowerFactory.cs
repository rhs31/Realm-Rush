using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerPrefab;
    Queue<Tower> towerQueue = new Queue<Tower>();

    

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;

        if(numTowers < towerLimit)
        {
            InstantiateNewower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }


    private void InstantiateNewower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;

        newTower.baseWaypoint = baseWaypoint;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower()
    {
        var oldTower = towerQueue.Dequeue();
        // set the placeable flags
        // set the baseWaypoints
        towerQueue.Enqueue(oldTower);
    }
}
