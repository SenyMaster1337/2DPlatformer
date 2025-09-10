using UnityEngine;

public class CanvasRotationSaver : MonoBehaviour
{
    private Quaternion _fixedRotation;

    void Start()
    {
        _fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = _fixedRotation;
    }
}
