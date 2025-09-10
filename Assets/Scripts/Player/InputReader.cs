using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const int MouseButtonAttack = 0;
    private const int MouseButtonUseAbility = 1;
    private const KeyCode KeyW = KeyCode.W;

    public float Direction { get; private set; }

    public bool IsJumpButtonClicked { get; private set; }

    public bool IsAttackButtonClicked { get; private set; }

    public bool IsUseAbilityButtonClicked { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        IsJumpButtonClicked = Input.GetKeyDown(KeyW);

        IsAttackButtonClicked = Input.GetMouseButton(MouseButtonAttack);

        IsUseAbilityButtonClicked = Input.GetMouseButton(MouseButtonUseAbility);
    }
}
