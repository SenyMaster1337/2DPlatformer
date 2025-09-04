using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();

        if (_boxCollider2D != null)
        {
            _boxCollider2D.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerHealth healthPlayer))
        {
            healthPlayer.TakeDamage(_damage);

            if (healthPlayer.Value <= 0)
            {
                Destroy(healthPlayer.gameObject);
            }
        }
    }
}
