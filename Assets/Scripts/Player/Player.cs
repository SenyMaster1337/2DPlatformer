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
    [SerializeField] private PlayerAttacker _playerAttacker;
    [SerializeField] private float _health;

    private Rigidbody2D _rigidbody;
    private int _rotationValueRight = 0;
    private int _rotationValueleft = 180;

    public float Health => _health;

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
        if (_inputHandler.IsAttackButtonClicked)
        {
            _animationController.PlayAttack();
            _playerAttacker.Attack();
        }

        if (_inputHandler.Direction > 0)
        {
            _flipper.Flip(transform, _rotationValueRight);
        }
        
        if (_inputHandler.Direction < 0)
        {
            _flipper.Flip(transform, _rotationValueleft);
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

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void TakeHeal(int heal)
    {
        _health += heal;
    }
}
