using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Responsible of the paddle movement in game.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PaddleMovement : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private Rigidbody2D paddleBody;
    [SerializeField] private float moveSpeed = 10f;

    #endregion


    #region Fields

    private Vector2 _moveVector = Vector2.zero;
    private InputActions _inputs;

    #endregion


    #region Unity Built-Ins

    private void Awake()
    {
        _inputs = new InputActions();
        TryGetComponent(out paddleBody);
    }

    private void FixedUpdate()
    {
        paddleBody.velocity = moveSpeed * _moveVector;
    }

    #endregion


    #region Unity Events

    private void OnEnable()
    {
        _inputs.Enable();
        _inputs.Player.Movement.performed += OnMovementPerformed;
        _inputs.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        _inputs.Disable();
        _inputs.Player.Movement.performed -= OnMovementPerformed;
        _inputs.Player.Movement.canceled -= OnMovementCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        _moveVector = context.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        _moveVector = Vector2.zero;
    }

    #endregion
}
