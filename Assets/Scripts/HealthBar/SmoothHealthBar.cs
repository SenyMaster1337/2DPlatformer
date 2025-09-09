using UnityEngine;

public class SmoothHealthBar : PlayerHealthBar
{
    private float _changeValue = 0.1f;
    private float _healthSliderValue;
    private float _healthCurrentValue;

    private void OnEnable()
    {
        _health.HealthChanged += Init;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= Init;
    }

    private void Update()
    {
        ChangeHealth();
    }

    public void Init()
    {
        _healthSliderValue = _healthSlider.Value;
        _healthCurrentValue = _health.CurrentValue;
    }

    public override void ChangeHealth()
    {
        if (_healthSlider.Value != _health.CurrentValue / _health.MaxValue)
        {
            _healthSliderValue = Mathf.Lerp(_healthSliderValue, _health.CurrentValue / _health.MaxValue, _changeValue);
            _healthCurrentValue = Mathf.Lerp(_healthCurrentValue, _healthSliderValue * _health.MaxValue, _changeValue);
            _healthSlider.ChangeValue(_healthSliderValue);
            _healthTextValue.ChangeText(_healthCurrentValue, _health.MaxValue);
        }
    }
}
