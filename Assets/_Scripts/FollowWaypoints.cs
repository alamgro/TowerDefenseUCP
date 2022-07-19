using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    [SerializeField] private string _pathName;
    [SerializeField] private List<Vector3> _waypointsPositions = new List<Vector3>();
    [Header("Movement attributes")]
    [SerializeField] private float minimumStopDistance;
    [SerializeField] private float movementSpeed;

    private int _currentWaypointIndex = 0;

    private void Start()
    {
        GetWaypoints();
        StartCoroutine(MoveToNextWaypoint());

    }

    private void GetWaypoints()
    {
        Transform path = GameObject.Find(_pathName).transform;

        foreach (Transform waypointTransform in path)
        {
            _waypointsPositions.Add(waypointTransform.position);
        }
    }

    private IEnumerator MoveToNextWaypoint()
    {
        float distance = Vector3.Distance(transform.position, _waypointsPositions[_currentWaypointIndex]);

        while (distance >= minimumStopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypointsPositions[_currentWaypointIndex], movementSpeed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, _waypointsPositions[_currentWaypointIndex]);

            yield return null;
        }

        if(_currentWaypointIndex < _waypointsPositions.Count - 1)
        {
            _currentWaypointIndex++;
            StartCoroutine(MoveToNextWaypoint());
        }
    }
}
