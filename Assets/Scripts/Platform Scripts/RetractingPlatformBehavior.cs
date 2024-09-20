using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractingPlatformBehavior : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Transform waypoint1;
    [SerializeField] Transform waypoint2;
    [SerializeField] Transform currentWaypoint;

    [SerializeField] float waitTime = 2;
    [SerializeField] float speed = 2;
    [SerializeField] bool isMovingLeft;

    private float timer;

    private void Start()
    {
        currentWaypoint = waypoint1;
        timer = waitTime;
    }

    private void Update()
    {

        if (Mathf.Abs(platform.transform.position.z - currentWaypoint.position.z) <= 0.005f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                ChangeWaypoint();
                timer = waitTime;
            }
        }
        else
        {
            var step = speed * Time.deltaTime;
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentWaypoint.position, step);
        }
    }

    private void ChangeWaypoint()
    {
        if (currentWaypoint == waypoint1)
        {
            currentWaypoint = waypoint2;
        }
        else
        {
            currentWaypoint = waypoint1;
        }
    }
}
