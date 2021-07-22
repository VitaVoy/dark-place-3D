using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] _waypoints;


    int _CurrentWaypointIndex;      

    void Start()
    {
        navMeshAgent.SetDestination(_waypoints[0].position);
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
            navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
        }
    }
}
