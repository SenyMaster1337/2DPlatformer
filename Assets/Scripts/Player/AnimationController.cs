using UnityEngine;

public class AnimatorParameters : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
    public readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));

    public void PlayRun()
    {
        _animator.SetBool(IsWalking, true);
    }

    public void StopRun()
    {
        _animator.SetBool(IsWalking, false);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(IsAttack);
    }
}
