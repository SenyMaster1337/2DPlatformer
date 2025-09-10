using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class HealthDrainer : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _timeUsageAbility;
    [SerializeField] private float _takeoverValue;
    [SerializeField] private float _timeCooldown;
    [SerializeField] private float _absorptionRate;

    public event Action AbilityActivated;
    public event Action<float> CooldownDeactivated;

    public bool IsAbilityActive { get; private set; }

    public bool IsOnCooldown { get; private set; }

    public float TimeUsageAbility => _timeUsageAbility;

    public float TimeCooldown => _timeCooldown;

    private bool _isEnemyInTrigger = false;

    private Coroutine _coroutine;
    private CircleCollider2D _circleCollider;
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();

        if (_circleCollider != null)
        {
            _circleCollider.isTrigger = true;
        }

        IsAbilityActive = false;
        IsOnCooldown = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            _isEnemyInTrigger = true;
            _enemyHealth = enemyHealth;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            if (enemyHealth.CurrentValue <= 0)
            {
                Destroy(enemyHealth.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            _isEnemyInTrigger = false;
        }
    }

    public void StartActivateAbilityCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountUsageAbility());
    }

    private void StartDrainCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountDrainHealth());
    }

    private void StartCooldownCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountCooldown());
    }

    private IEnumerator CountUsageAbility()
    {
        IsAbilityActive = true;
        AbilityActivated.Invoke();

        StartDrainCount();

        yield return new WaitForSeconds(_timeUsageAbility);

        IsAbilityActive = false;

        StartCooldownCount();
    }

    private IEnumerator CountDrainHealth()
    {
        var wait = new WaitForSeconds(_absorptionRate);

        while (IsAbilityActive == true)
        {
            if (_isEnemyInTrigger == true)
            {
                DrainHealth();
            }

            yield return wait;
        }
    }

    private IEnumerator CountCooldown()
    {
        IsOnCooldown = true;

        yield return new WaitForSeconds(_timeCooldown);

        IsOnCooldown = false;
        CooldownDeactivated.Invoke(_timeUsageAbility);
    }

    private void DrainHealth()
    {
        _enemyHealth.TakeDamage(_takeoverValue);
        _playerHealth.TakeHeal(_takeoverValue);
    }
}
