using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected HealthSlider _healthSlider;
    [SerializeField] protected HealthText _healthTextValue;

    private void OnEnable()
    {
        _health.OnValueChanged += ChangeHealth;
    }

    private void OnDisable()
    {
        _health.OnValueChanged -= ChangeHealth;
    }

    private void Start()
    {
        _healthSlider.ChangeValue(_health.CurrentValue);
        _healthTextValue.ChangeValue(_health.CurrentValue, _health.MaxValue);
    }

    public virtual void ChangeHealth()
    {
        _healthSlider.ChangeValue(_health.CurrentValue / _health.MaxValue);
        _healthTextValue.ChangeValue(_health.CurrentValue, _health.MaxValue);
    }
}
