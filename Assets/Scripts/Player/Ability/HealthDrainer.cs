using System;
using System.Collections;
using UnityEngine;

public class HealthDrainer : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private float _timeUsageAbility;
    [SerializeField] private float _takeoverValue;
    [SerializeField] private float _timeCooldown;
    [SerializeField] private float _absorptionRate;
    [SerializeField] private AbilityPosition _abilityPosition;
    [SerializeField] private float _abilityRadius;

    public event Action AbilityActivated;
    public event Action AbilityDeactivated;

    public bool IsAbilityActive { get; private set; }

    public bool IsOnCooldown { get; private set; }

    public float TimeUsageAbility => _timeUsageAbility;

    public float TimeCooldown => _timeCooldown;

    private Coroutine _coroutine;
    private Health _enemyHealth;
    private Collider2D[] _hitCollidersBuffer = new Collider2D[10];
    private int _collidersFoundCount;

    private void Awake()
    {
        IsAbilityActive = false;
        IsOnCooldown = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_abilityPosition.transform.position, _abilityRadius);
    }

    public void StartActivateAbility()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ActivateAbility());
    }

    private void StartHandlerEnemy()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(HandlerEnemy());
    }

    private void StartActivateCooldown()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ActivateCooldown());
    }

    private IEnumerator ActivateAbility()
    {
        IsAbilityActive = true;
        AbilityActivated.Invoke();

        StartHandlerEnemy();

        yield return new WaitForSeconds(_timeUsageAbility);

        IsAbilityActive = false;
        AbilityDeactivated.Invoke();

        StartActivateCooldown();
    }

    private IEnumerator HandlerEnemy()
    {
        var wait = new WaitForSeconds(_absorptionRate);

        while (IsAbilityActive == true)
        {
            CheckEnemy();
            yield return wait;
        }
    }

    private IEnumerator ActivateCooldown()
    {
        IsOnCooldown = true;

        yield return new WaitForSeconds(_timeCooldown);

        IsOnCooldown = false;
    }

    private void DrainHealth()
    {
        _enemyHealth.TakeDamage(_takeoverValue);
        _playerHealth.TakeHeal(_takeoverValue);
    }

    private void CheckEnemy()
    {
        _collidersFoundCount = Physics2D.OverlapCircleNonAlloc(_abilityPosition.transform.position, _abilityRadius, _hitCollidersBuffer);

        if (_collidersFoundCount != 0)
        {
            for (int i = 0; i < _collidersFoundCount; i++)
            {
                if (_hitCollidersBuffer[i].TryGetComponent(out Health enemyHealth))
                {
                    _enemyHealth = enemyHealth;
                    DrainHealth();
                }
            }
        }
    }
}
