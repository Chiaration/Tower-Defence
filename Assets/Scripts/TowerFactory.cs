using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;

    Queue<Tower> towerQueue = new Queue<Tower>();

    int currentTowers;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentTowers = towerQueue.Count;
        print(currentTowers);
    }

    public void AddTower(Waypoints baseWaypoint)
    {
        if (currentTowers <= towerLimit)
        {
            var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
            baseWaypoint.isPlaceable = false;
            currentTowers = currentTowers + 1;
            towerQueue.Enqueue(newTower);
        }
        else
        {
            var oldTower = towerQueue.Dequeue();
            
            
            towerQueue.Enqueue(oldTower);
        }
    }
}
