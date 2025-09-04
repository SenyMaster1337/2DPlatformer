using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Follower _follower;
    [SerializeField] private EnemyDamager _damager;
    [SerializeField] private float _health;

    private Vector2 _previousPosition;
    private float _currentVelocityX;
    private int _rotationValueRight = 0;
    private int _rotationValueleft = 180;

    public float Health => _health;

    private void Update()
    {
        if (_follower.IsFollower)
        {
            _follower.Follow();
        }
        else
        {
            _patroller.MoveToPoint();
        }

        _currentVelocityX = (transform.position.x - _previousPosition.x) / Time.deltaTime;
        _previousPosition = transform.position;

        if (_currentVelocityX > 0)
        {
            _flipper.Flip(transform, _rotationValueRight);
        }

        if (_currentVelocityX < 0)
        {
            _flipper.Flip(transform, _rotationValueleft);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}