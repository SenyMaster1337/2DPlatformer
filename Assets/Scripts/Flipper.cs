using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion _rotation;

    public void FlipRight(Transform transform)
    {
        _rotation.y = 0;
        transform.rotation = _rotation;
    }

    public void FlipLeft(Transform transform)
    {
        _rotation.y = 180;
        transform.rotation = _rotation;
    }
}
