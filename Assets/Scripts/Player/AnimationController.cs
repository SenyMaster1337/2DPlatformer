using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Animator _animator;

    public readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));

    private void Update()
    {
        if (_inputHandler.Direction != 0)
        {
            _animator.SetBool(IsWalking, true);
        }
        else
        {
            _animator.SetBool(IsWalking, false);
        }
    }
}
