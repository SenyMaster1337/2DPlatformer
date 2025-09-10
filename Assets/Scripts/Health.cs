using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    private float _minValue = 0;

    public event Action OnValueChanged;

    public float MaxValue => _maxValue;

    public float MinValue => _minValue;

    public float CurrentValue { get; private set; }

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
            OnValueChanged?.Invoke();
        }

    }

    public void TakeHeal(float heal)
    {
        if (heal >= 0)
        {
            CurrentValue += heal;
            LimitValue();
            OnValueChanged?.Invoke();
        }

    }

    private void LimitValue()
    {
        CurrentValue = Mathf.Clamp(CurrentValue, _minValue, _maxValue);
    }
}
