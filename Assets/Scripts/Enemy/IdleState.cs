using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IdleState : State
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed;

    private Transform _currentWaypoint;
    private int _currentWaypointNumber;

    private void Start()
    {
        if (_waypoints != null)
        {
            _currentWaypointNumber = 0;
            _currentWaypoint = _waypoints[_currentWaypointNumber];
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint.transform.position, _speed * Time.deltaTime);

        if (transform.position.x != _currentWaypoint.position.x)
            return;

        if (_waypoints.Count > _currentWaypointNumber + 1)
            _currentWaypointNumber++;
        else if (_waypoints.Count == _currentWaypointNumber + 1)
            _currentWaypointNumber = 0;

        _currentWaypoint = _waypoints[_currentWaypointNumber];
    }
}
