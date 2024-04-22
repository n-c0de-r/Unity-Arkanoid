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


    #region Fields

    private Vector2 _moveVector = Vector2.zero;

    #endregion


    #region Unity Built-Ins

    private void Awake()
    {
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
        moveAction.action.performed += OnMovementPerformed;
        moveAction.action.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        moveAction.action.performed -= OnMovementPerformed;
        moveAction.action.canceled -= OnMovementCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
       // paddleBody.constraints = paddleBody.constraints | RigidbodyConstraints2D.FreezePositionX;
        _moveVector = context.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        _moveVector = Vector2.zero;
        // paddleBody.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    #endregion
}
