using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField ]private float moveSpeed = 10f;
    private Vector2 moveVector = Vector2.zero;
    private InputActions inputs;

    private void Awake()
    {
        inputs = new InputActions();
    }

    private void FixedUpdate()
    {
        playerBody.velocity = moveSpeed * moveVector;
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Movement.performed += OnMovementPerformed;
        inputs.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.Movement.performed -= OnMovementPerformed;
        inputs.Player.Movement.canceled -= OnMovementCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        moveVector = Vector2.zero;
    }
}
