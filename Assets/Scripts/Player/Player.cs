using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _playerMover.TranslateDirection(_rigidbody, _inputHandler);
    }

    private void Update()
    {
        if (_inputHandler.Direction > 0)
        {
            _flipper.FlipRight(transform);
        }

        if (_inputHandler.Direction < 0)
        {
            _flipper.FlipLeft(transform);
        }

        if (_inputHandler.IsJumpButtonClicked && _groundChecker.GetPermissionJump())
        {
            _jumper.Jump(_rigidbody);
        }

        if (_inputHandler.Direction != 0)
        {
            _animationController.PlayRun();
        }
        else
        {
            _animationController.StopRun();
        }
    }
}
