using TMPro;
using UnityEngine;

public class AbilityTimeText : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeValue;

    public void ChangeText(float currentValue)
    {
        _timeValue.SetText($"Time Ability: {Mathf.Round(currentValue)}");
    }
}
