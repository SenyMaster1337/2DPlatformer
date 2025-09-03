using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float radiusGround;

    public bool GetPermissionJump()
    {
        return Physics2D.OverlapCircle(transform.position, radiusGround, _ground);
    }
}
