using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const KeyCode KeyW = KeyCode.W;

    public event Action JumpButtonClicked;
    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(KeyW))
        {
            JumpButtonClicked?.Invoke();
        }
    }
}
