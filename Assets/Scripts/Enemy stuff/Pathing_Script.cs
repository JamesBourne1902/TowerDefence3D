using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing_Script : MonoBehaviour
{
    public Stats_Script stats;

    public Waypoint_Script waypoints;
    private int index = 0;
    private Transform currentTarget;
    private bool looking = true;
    private bool canMove = false;

    private void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("waypoint").GetComponent<Waypoint_Script>();
        currentTarget = waypoints.waypoints[0];
        Invoke("startMoving", 0.5f);
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 myPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 targetPosition = new Vector3(currentTarget.position.x, transform.position.y, currentTarget.position.z);
            transform.position = Vector3.MoveTowards(myPosition, targetPosition, stats.speed * Time.deltaTime);

            if (myPosition.x == targetPosition.x && myPosition.z == targetPosition.z)
            {
                index += 1;
                currentTarget = waypoints.waypoints[index];
                looking = false;
            }

            if (!looking)
            {
                transform.LookAt(currentTarget.position);
                looking = true;
            }
        }
    }

    private void startMoving()
    {
        canMove = true;
    }
}
