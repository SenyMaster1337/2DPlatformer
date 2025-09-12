using UnityEngine;
using UnityEngine.UI;

public class UniversalSlider : MonoBehaviour
{
    [SerializeField] protected Slider _slider;

    public void ChangeValue(float value)
    {
        _slider.value = value;
    }
}
