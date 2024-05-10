using UnityEngine;

public class PatrollerEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _currentWaypoint = 0;

    private void Update()
    {
        if (Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) <= 1)
            if (_currentWaypoint == _waypoints.Length - 1)
            {
                _currentWaypoint = 0;
            }
            else
            {
                _currentWaypoint++;
            }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _enemySpeed * Time.deltaTime);

        Flip();
    }

    private void Flip()
    {
        if (_waypoints[_currentWaypoint].position.x > transform.position.x)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
