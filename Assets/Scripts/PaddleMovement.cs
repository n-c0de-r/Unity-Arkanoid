using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _paddleBody;
    [SerializeField] private float moveSpeed = 10f;
    private Vector2 _moveVector = Vector2.zero;
    private InputActions _inputs;

    private void Awake()
    {
        _inputs = new InputActions();
        TryGetComponent(out _paddleBody);
    }

    private void FixedUpdate()
    {
        _paddleBody.velocity = moveSpeed * _moveVector;
    }

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
}
