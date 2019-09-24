using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoints> path;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(printAllWaypoints());
    }

    IEnumerator printAllWaypoints()
    {
        print("Starting Patrol");
        foreach (Waypoints waypoint in path)
        {
            print("Visiting Block: " + waypoint.name);
            var waypointTransform = waypoint.transform.position;
            transform.position = new Vector3(waypointTransform.x, 2.5f, waypointTransform.z);
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
