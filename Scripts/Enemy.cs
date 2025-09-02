using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _moveSpeed;

    private float _distance;
    private float _thresholdValue = 0.1f;
    private int _currentWaypoint = 0;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position, _moveSpeed * Time.deltaTime);
        _distance = Vector2.Distance(transform.position, _wayPoints[_currentWaypoint].position);

        if (_distance <= _thresholdValue)
            _currentWaypoint = (_currentWaypoint + 1) % _wayPoints.Length;
    }
}
