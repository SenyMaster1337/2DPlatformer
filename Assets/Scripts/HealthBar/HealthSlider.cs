using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public float Value => _slider.value;

    public void ChangeValue(float value)
    {
        _slider.value = value;
    }
}
