using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5; 
    
    int currentTowers = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTower(Waypoints baseWaypoint)
    {
        if (currentTowers < towerLimit)
        {
            Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
            baseWaypoint.isPlaceable = false;
            currentTowers = currentTowers + 1;
        }
        else
        {
            print(currentTowers);
        }
    }
}
