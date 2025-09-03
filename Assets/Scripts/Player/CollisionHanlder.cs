using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CollisionHanlder : MonoBehaviour
{
    private CircleCollider2D _circleCollider;

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
    }
}
