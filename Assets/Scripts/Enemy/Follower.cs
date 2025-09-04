using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Follower : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private CircleCollider2D _circleCollider;
    private Player _player;

    private Transform _parentTransform;

    public bool IsFollower {  get; private set; }

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();

        if (_circleCollider != null)
        {
            _circleCollider.isTrigger = true;
        }
    }

    private void Start()
    {
        _parentTransform = transform.parent;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            IsFollower = true;
            _player = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            IsFollower = false;
        }
    }

    public void Follow()
    {
        _parentTransform.position = Vector2.MoveTowards(_parentTransform.position, _player.transform.position, _moveSpeed * Time.deltaTime);
    }
}
