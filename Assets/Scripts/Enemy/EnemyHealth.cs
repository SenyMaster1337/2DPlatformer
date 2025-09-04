using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _value;

    public float Value => _value;

    public void TakeDamage(int damage)
    {
        _value -= damage;
    }
}
