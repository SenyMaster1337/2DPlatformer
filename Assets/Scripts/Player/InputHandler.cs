using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const KeyCode KeyW = KeyCode.W;

    public bool IsJumpButtonClicked { get; private set; }

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        IsJumpButtonClicked = Input.GetKeyDown(KeyW);
    }
}
