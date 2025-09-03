using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));

    public void PlayRun()
    {
        _animator.SetBool(IsWalking, true);
    }

    public void StopRun()
    {
        _animator.SetBool(IsWalking, false);
    }
}
