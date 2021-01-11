using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towersQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towersQueue.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MovingExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);

        tower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towersQueue.Enqueue(tower);
    }

    private void MovingExistingTower(Waypoint baseWaypoint)
    {
        var oldTower = towersQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;

        baseWaypoint.isPlaceable = false;
        oldTower.baseWaypoint = baseWaypoint;
        oldTower.transform.position = baseWaypoint.transform.position;
        towersQueue.Enqueue(oldTower);
    }
}
