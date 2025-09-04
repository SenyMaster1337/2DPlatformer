using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private AnimatorParameters _animatorParameters;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAttacker _playerAttacker;

    private Rigidbody2D _rigidbody;
    private int _rotationValueRight = 0;
    private int _rotationValueleft = 180;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _playerMover.TranslateDirection(_rigidbody, _inputReader);
    }

    private void Update()
    {
        if (_inputReader.IsAttackButtonClicked)
        {
            _animatorParameters.PlayAttack();
            _playerAttacker.Attack();
        }

        if (_inputReader.Direction > 0)
        {
            _flipper.Flip(transform, _rotationValueRight);
        }
        
        if (_inputReader.Direction < 0)
        {
            _flipper.Flip(transform, _rotationValueleft);
        }

        if (_inputReader.IsJumpButtonClicked && _groundChecker.GetPermissionJump())
        {
            _jumper.Jump(_rigidbody);
        }

        if (_inputReader.Direction != 0)
        {
            _animatorParameters.PlayRun();
        }
        else
        {
            _animatorParameters.StopRun();
        }
    }
}
