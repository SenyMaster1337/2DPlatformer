using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Flipper _flipper;

    private Vector2 _previousPosition;
    private float _currentVelocityX;

    private void Update()
    {
        _patroller.MoveToPoint();

        _currentVelocityX = (transform.position.x - _previousPosition.x) / Time.deltaTime;
        _previousPosition = transform.position;

        if (_currentVelocityX > 0)
        {
            _flipper.FlipRight(transform);
        }

        if (_currentVelocityX < 0)
        {
            _flipper.FlipLeft(transform);
        }
    }
}