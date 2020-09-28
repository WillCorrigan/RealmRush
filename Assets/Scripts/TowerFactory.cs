using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        var towerCount = towerQueue.Count;
        if (towerCount >= towerLimit)
        {
            MoveExistingTower(baseWaypoint);
        }
        else
        {
            InstantiateNewTower(baseWaypoint);
        }
    }
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform.transform;
        baseWaypoint.isPlaceable = false;
        newTower.baseWaypoint = baseWaypoint;
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var lastTower = towerQueue.Dequeue();

        lastTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        lastTower.baseWaypoint = newBaseWaypoint;

        lastTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(lastTower);
    }


}
