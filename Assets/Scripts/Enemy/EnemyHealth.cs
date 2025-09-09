using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    private float _minValue = 0;

    public float MaxValue => _maxValue;

    public float MinValue => _minValue;

    public float CurrentValue { get; private set; }

    public event Action HealthChanged;

    private void Awake()
    {
        CurrentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            CurrentValue -= damage;
            LimitValue();
            HealthChanged?.Invoke();
        }

    }

    private void LimitValue()
    {
        CurrentValue = Mathf.Clamp(CurrentValue, _minValue, _maxValue);
    }
}
