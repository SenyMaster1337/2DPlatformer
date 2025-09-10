using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _radiusDamage;
    [SerializeField] private AttackPosition _attackPosition;

    public void Attack()
    {
        Collider2D enemies = Physics2D.OverlapCircle(_attackPosition.transform.position, _radiusDamage);

        if (enemies != null)
        {
            if (enemies.TryGetComponent(out Health enemyHealth))
            {
                enemyHealth.TakeDamage(_damage);

                if (enemyHealth.CurrentValue <= 0)
                {
                    Destroy(enemyHealth.gameObject);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackPosition.transform.position, _radiusDamage);
    }
}
