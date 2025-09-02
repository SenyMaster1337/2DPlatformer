using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    private CircleCollider2D _circleCollider;

    public event Action<Coin> CoinDiscovered;

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
            CoinDiscovered?.Invoke(coin);
        }
    }
}
