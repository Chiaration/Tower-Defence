using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.5f;
    [SerializeField] private ParticleSystem goalParticle;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Pathfinding pathfinding = FindObjectOfType<Pathfinding>();
        var path = pathfinding.getPath();
        StartCoroutine(followPath(path));
    }

    IEnumerator followPath(List<Waypoints> path)
    {
        foreach (Waypoints waypoint in path)
        {
            var waypointTransform = waypoint.transform.position;
            transform.position = new Vector3(waypointTransform.x, 2.5f, waypointTransform.z);
            yield return new WaitForSeconds(movementSpeed);
        }

        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        
        float destoryDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destoryDelay);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
