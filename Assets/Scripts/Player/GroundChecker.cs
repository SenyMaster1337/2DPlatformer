using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _radiusGround;

    public bool GetPermissionJump()
    {
        return Physics2D.OverlapCircle(transform.position, _radiusGround, _ground);
    }
}
