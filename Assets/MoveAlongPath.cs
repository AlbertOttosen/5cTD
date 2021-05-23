using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAlongPath : MonoBehaviour
{
    public float speed;
    Waypoints waypoints;
    int waypoint_idx = 0;
    public float noice = 0.1f;
    Vector2 nextTarget;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("waypoints").GetComponent<Waypoints>();
        nextTarget = AddNoice(waypoints.waypoints[waypoint_idx].position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, nextTarget, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, nextTarget) < 0.1F) {
            if (waypoint_idx < waypoints.waypoints.Length-1) {
                waypoint_idx++;
                nextTarget = AddNoice(waypoints.waypoints[waypoint_idx].position);
            } else {
                //end of path
                GameObject canvas = GameObject.Find("HealthAndEnergy");
                canvas.GetComponent<HealthAndEnergy>().LoseLife();
                Destroy(gameObject);
            }
            
        }
    }

    Vector2 AddNoice(Vector2 pos) {
        return pos + new Vector2(Random.Range(-noice, noice), Random.Range(-noice, noice));
    }
}
