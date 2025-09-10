using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] protected EnemyHealth _health;
    [SerializeField] protected HealthSlider _healthSlider;
    [SerializeField] protected HealthText _healthTextValue;

    private Quaternion _fixedRotation;

    private void OnEnable()
    {
        _health.HealthChanged += ChangeHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeHealth;
    }

    private void Start()
    {
        _fixedRotation = transform.rotation;
        _healthSlider.ChangeValue(_health.CurrentValue);
        _healthTextValue.ChangeText(_health.CurrentValue, _health.MaxValue);
    }

    private void LateUpdate()
    {
        transform.rotation = _fixedRotation;
    }

    public virtual void ChangeHealth()
    {
        _healthSlider.ChangeValue(_health.CurrentValue / _health.MaxValue);
        _healthTextValue.ChangeText(_health.CurrentValue, _health.MaxValue);
    }
}
