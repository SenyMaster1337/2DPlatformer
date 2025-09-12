using System.Collections;
using UnityEngine;

public class AbilityBar : MonoBehaviour
{
    [SerializeField] private HealthDrainer _healthDrainer;
    [SerializeField] private AbilitySlider _abilitySlider;

    private Coroutine _coroutine;
    private float _currentTimeValue;
    private float _onesecond = 1.0f;

    private void OnEnable()
    {
        _healthDrainer.AbilityActivated += StartUseAbilityTimeCount;
        _healthDrainer.AbilityDeactivated += StartCooldownTimeCount;
    }

    private void OnDisable()
    {
        _healthDrainer.AbilityActivated -= StartUseAbilityTimeCount;
        _healthDrainer.AbilityDeactivated -= StartCooldownTimeCount;
    }

    private void Start()
    {
        _abilitySlider.ChangeValue(_healthDrainer.TimeUsageAbility);
    }

    public void ChangeTime(float timeValue)
    {
        _abilitySlider.ChangeValue(timeValue);
    }

    private void StartUseAbilityTimeCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountTimeUseAbility());
    }
    private void StartCooldownTimeCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountTimeCooldown());
    }

    private IEnumerator CountTimeUseAbility()
    {
        var wait = new WaitForSeconds(_onesecond);
        _currentTimeValue = _healthDrainer.TimeUsageAbility;

        while (_currentTimeValue >= 0)
        {
            ChangeTime(_currentTimeValue-- / _healthDrainer.TimeUsageAbility);
            yield return wait;
        }
    }

    private IEnumerator CountTimeCooldown()
    {
        var wait = new WaitForSeconds(_onesecond);
        _currentTimeValue = 0;

        while (_currentTimeValue <= _healthDrainer.TimeCooldown)
        {
            ChangeTime(_currentTimeValue++ / _healthDrainer.TimeCooldown);
            yield return wait;
        }
    }
}
