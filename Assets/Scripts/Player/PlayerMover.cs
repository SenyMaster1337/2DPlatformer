using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public void TranslateDirection(Rigidbody2D rigidbody, InputReader inputHandler)
    {
        rigidbody.velocity = new Vector2(inputHandler.Direction * _moveSpeed, rigidbody.velocity.y);
    }
}
