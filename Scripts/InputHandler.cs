using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    public float Direction { get; private set; }
    public event Action JumpButtonClicked;

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(KeyCode.W))
        {
            JumpButtonClicked?.Invoke();
        }
    }
}
