using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AICarController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform target; // Set the target (e.g., player) in the Unity Editor

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (target == null)
        {
            Debug.LogError("Target not assigned for AICarController");
        }
    }

    void Update()
    {
        if (target != null)
        {
            SetDestination();
        }
    }

    void SetDestination()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(target.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(hit.position);
        }
        else
        {
            Debug.LogError("Could not find a valid position on the NavMesh for the target.");
        }
    }
}