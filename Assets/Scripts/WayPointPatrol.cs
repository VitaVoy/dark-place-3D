using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform _targetWaypoint;
    private int _targetWaypointIndex;
    private float _pointDistance = 0.1f;
    private float _lastWaypointIndex;
    private float _speed = 0.3f;

    private void Start()
    {
        _targetWaypoint = waypoints[_targetWaypointIndex];
        _lastWaypointIndex = waypoints.Count - 1;
    }

    private void Update()
    {
        float _movementStep = _speed * Time.deltaTime;

        float _distance = Vector3.Distance(transform.position, _targetWaypoint.position);
        CheckDistanceToWaypoint(_distance);

        transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint.position, _movementStep);
    }

    private void CheckDistanceToWaypoint(float _currentDisance)
    {
        if (_currentDisance <= _pointDistance)
        {
            _targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    private void UpdateTargetWaypoint()
    {
        if (_targetWaypointIndex > _lastWaypointIndex)
        {
            _targetWaypointIndex = 0;
        }
        _targetWaypoint = waypoints[_targetWaypointIndex];
    }
}
