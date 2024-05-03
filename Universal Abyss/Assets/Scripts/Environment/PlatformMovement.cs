using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _platformMovementSpeed;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypoint = 0;

    private void Update()
    {
        if (Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) <= 1)
        {
            if (_currentWaypoint == _waypoints.Length - 1)
            {
                _currentWaypoint = 0;
            }
            else
            {
                _currentWaypoint++;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _platformMovementSpeed * Time.deltaTime);
    }
}