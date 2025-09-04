using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private CollisionHanlder _collisionHanlder;
    [SerializeField] private float _value;

    public float Value => _value;

    private void OnEnable()
    {
        _collisionHanlder.PlayerHealing += TakeHeal;
    }

    private void OnDisable()
    {
        _collisionHanlder.PlayerHealing -= TakeHeal;
    }

    public void TakeDamage(int damage)
    {
        _value -= damage;
    }

    private void TakeHeal(int heal)
    {
        _value += heal;
    }
}
