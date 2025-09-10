using System.Collections;
using UnityEngine;

public class AbilityInfoShower : MonoBehaviour
{
    [SerializeField] private HealthDrainer _healthDrainer;
    [SerializeField] private AbilityTimeText _abilityTimeText;

    private Quaternion _fixedRotation;
    private Coroutine _coroutine;
    private float _timeValue;
    private float _Onesecond = 1.0f;

    private void OnEnable()
    {
        _healthDrainer.AbilityActivated += StartChangeTimeCount;
        _healthDrainer.CooldownDeactivated += ChangeTime;
    }

    private void OnDisable()
    {
        _healthDrainer.AbilityActivated -= StartChangeTimeCount;
        _healthDrainer.CooldownDeactivated -= ChangeTime;
    }

    private void Start()
    {
        _fixedRotation = transform.rotation;
        ChangeTime(_healthDrainer.TimeUsageAbility);
    }

    private void LateUpdate()
    {
        transform.rotation = _fixedRotation;
    }

    private void StartChangeTimeCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountChangeTime());
    }

    private IEnumerator CountChangeTime()
    {
        var wait = new WaitForSeconds(_Onesecond);
        _timeValue = _healthDrainer.TimeUsageAbility;

        while (_timeValue >= 0)
        {
            ChangeTime(_timeValue--);
            yield return wait;
        }
    }

    public void ChangeTime(float timeValue)
    {
        _abilityTimeText.ChangeText(timeValue);
    }
}
