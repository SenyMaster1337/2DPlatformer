using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private Quaternion _rotation;

    private void OnEnable()
    {
        _inputHandler.JumpButtonClicked += Jump;
    }

    private void OnDisable()
    {
        _inputHandler.JumpButtonClicked -= Jump;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_inputHandler.Direction * _moveSpeed, _rigidbody.velocity.y);

        Flip();
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        if (_inputHandler.Direction > 0)
        {
            _rotation.y = 0;
            transform.rotation = _rotation;
        }

        if (_inputHandler.Direction < 0)
        {
            _rotation.y = 180;
            transform.rotation = _rotation;
        }
    }
}
