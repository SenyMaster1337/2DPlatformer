using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CollisionHanlder : MonoBehaviour
{
    private CircleCollider2D _circleCollider;

    public event Action<int> PlayerHealing;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();

        if (_circleCollider != null)
        {
            _circleCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
        }

        if (collider.gameObject.TryGetComponent(out Healer healer))
        {
            PlayerHealing?.Invoke(healer.HealValue);
            Destroy(healer.gameObject);
        }
    }
}
