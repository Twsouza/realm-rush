using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    public void AddTower(Waypoint baseWaypoint)
    {
        Tower[] towers = FindObjectsOfType<Tower>();
        if (towers.Length < towerLimit)
        {
            Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        }
        else
        {
            print("limit reached");
        }
    }
}
