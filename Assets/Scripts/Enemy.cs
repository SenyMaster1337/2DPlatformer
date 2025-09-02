using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _moveSpeed;

    private float _thresholdValue = 0.1f;
    private int _currentWaypoint = 0;
    private Vector2 _position;
    private Quaternion _rotation;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position, _moveSpeed * Time.deltaTime);
        _position = transform.position;

        if (_position.IsEnoughClose(_wayPoints[_currentWaypoint].position, _thresholdValue))
        {
            _currentWaypoint = (_currentWaypoint + 1) % _wayPoints.Length;

            if (_wayPoints[_currentWaypoint].rotation.y == 0)
            {
                _rotation.y = 180;
                transform.rotation = _rotation;
            }
            else
            {
                _rotation.y = 0;
                transform.rotation = _rotation;
            }
        }
    }
}