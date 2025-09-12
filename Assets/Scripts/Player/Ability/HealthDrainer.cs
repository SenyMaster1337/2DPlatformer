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
    [SerializeField] private EnemiesSearcher _enemiesSearcher;

    public event Action AbilityActivated;
    public event Action AbilityDeactivated;

    public bool IsAbilityActive { get; private set; }

    public bool IsOnCooldown { get; private set; }

    public float TimeUsageAbility => _timeUsageAbility;

    public float TimeCooldown => _timeCooldown;

    private Coroutine _coroutine;
    private Health _enemyHealth;
    
    private void Awake()
    {
        IsAbilityActive = false;
        IsOnCooldown = false;
    }

    public void StartActivateAbility()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ActivateAbility());
    }

    private void StartHandleEnemy()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(HandleEnemy());
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

        StartHandleEnemy();

        yield return new WaitForSeconds(_timeUsageAbility);

        IsAbilityActive = false;
        AbilityDeactivated.Invoke();

        StartActivateCooldown();
    }

    private IEnumerator HandleEnemy()
    {
        var wait = new WaitForSeconds(_absorptionRate);

        while (IsAbilityActive == true)
        {
            AttackEnemyWithinRadiusAbility();
            yield return wait;
        }
    }

    private IEnumerator ActivateCooldown()
    {
        IsOnCooldown = true;

        yield return new WaitForSeconds(_timeCooldown);

        IsOnCooldown = false;
    }

    private void AttackEnemyWithinRadiusAbility()
    {
        if (_enemiesSearcher.TryGetClosestEnemy(out Enemy closestEnemy, ref _enemyHealth))
        {
            DrainHealth();
        }
    }

    private void DrainHealth()
    {
        _enemyHealth.TakeDamage(_takeoverValue);
        _playerHealth.TakeHeal(_takeoverValue);
    }
}
