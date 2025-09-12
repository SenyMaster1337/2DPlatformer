using UnityEngine;

public class EnemiesSearcher : MonoBehaviour
{
    [SerializeField] private AbilityPosition _abilityPosition;
    [SerializeField] private float _abilityRadius;

    private Collider2D[] _hitCollidersBuffer = new Collider2D[10];
    private Vector2 _position;
    private int _collidersFoundCount;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_abilityPosition.transform.position, _abilityRadius);
    }

    public bool TryGetClosestEnemy(out Enemy closestEnemy, ref Health enemyHealth)
    {
        _collidersFoundCount = Physics2D.OverlapCircleNonAlloc(_abilityPosition.transform.position, _abilityRadius, _hitCollidersBuffer);
        float closestDistance = Mathf.Infinity;

        Enemy foundEnemy = null;
        closestEnemy = null;

        if (_collidersFoundCount == 0)
        {
            return false;
        }

        for (int i = 0; i < _collidersFoundCount; i++)
        {
            if (_hitCollidersBuffer[i].TryGetComponent(out Enemy enemy) && _hitCollidersBuffer[i].TryGetComponent(out Health health))
            {
                _position = transform.position;
                float distance = _position.SqrDistance(_hitCollidersBuffer[i].transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    foundEnemy = enemy;
                    enemyHealth = health;
                }
            }
        }

        closestEnemy = foundEnemy;
        return foundEnemy != null;
    }
}
