using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 2f;

    void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned for AICarController");
            return;
        }

        NavigateToWaypoint();
    }

    void NavigateToWaypoint()
    {
        Transform currentWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (currentWaypoint.position - transform.position).normalized;

        // Move towards the waypoint
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Rotate towards the waypoint
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Check if the car is close to the current waypoint
        float distanceToWaypoint = Vector3.Distance(transform.position, currentWaypoint.position);
        if (distanceToWaypoint < 1f)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}