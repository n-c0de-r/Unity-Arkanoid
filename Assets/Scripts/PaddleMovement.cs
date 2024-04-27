using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Responsible of the paddle movement in game.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PaddleMovement : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private InputActionReference moveAction;

    [SerializeField] private Rigidbody2D paddleBody;
    [SerializeField] private float moveSpeed = 15f;

    #endregion


    #region Unity Built-Ins

    private void Awake()
    {
        TryGetComponent(out paddleBody);
        moveAction.action.performed += OnMovementPerformed;
        moveAction.action.canceled += OnMovementCanceled;
    }

    #endregion


    #region Unity Events

    private void OnDestroy()
    {
        moveAction.action.performed -= OnMovementPerformed;
        moveAction.action.canceled -= OnMovementCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        paddleBody.constraints = RigidbodyConstraints2D.FreezeAll ^ RigidbodyConstraints2D.FreezePositionX;
        paddleBody.velocity = moveSpeed * context.ReadValue<Vector2>();

    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        paddleBody.constraints = RigidbodyConstraints2D.FreezeAll;
        paddleBody.velocity = Vector2.zero;

    }
    #endregion
}
