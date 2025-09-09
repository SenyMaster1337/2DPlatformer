using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthValue;

    public void ChangeText(float currentValue, float maxValue)
    {
        _healthValue.SetText($"{Mathf.Round(currentValue)}/{Mathf.Round(currentValue)}");
    }
}
