using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;

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
    }

    private void Update()
    {
        if (_inputHandler.Direction != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
