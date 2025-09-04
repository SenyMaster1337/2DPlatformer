using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Healer : MonoBehaviour
{
    [SerializeField] private int _healValue;

    private CircleCollider2D _circleCollider;

    public int HealValue => _healValue;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();

        if (_circleCollider != null)
        {
            _circleCollider.isTrigger = true;
        }
    }
}
