using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radiusDamage;
    [SerializeField] private AttackPosition _attackPosition;

    public void Attack()
    {
        Collider2D enemies = Physics2D.OverlapCircle(_attackPosition.transform.position, _radiusDamage);

        if (enemies != null)
        {
            if (enemies.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);

                if (enemy.Health <= 0)
                {
                    Destroy(enemy.gameObject);
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
