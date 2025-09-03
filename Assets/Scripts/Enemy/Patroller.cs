using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _moveSpeed;

    private float _thresholdValue = 0.1f;
    private int _currentWaypoint = 0;
    private Vector2 _position;

    public void MoveToPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position, _moveSpeed * Time.deltaTime);
        _position = transform.position;

        if (_position.IsEnoughClose(_wayPoints[_currentWaypoint].position, _thresholdValue))
        {
            _currentWaypoint = (_currentWaypoint + 1) % _wayPoints.Length;
        }
    }
}
