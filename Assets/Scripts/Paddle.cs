using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private InputActionAsset inputs;
    [SerializeField] private InputActionReference shootAction;

    #endregion


    #region Fields

    [Tooltip("The initial position to reset to after it is destroyed.")]
    private Vector2 _initialPosition;

    #endregion


    #region Unity Built-Ins

    private void FixedUpdate()
    {
    }

    #endregion


    #region Unity Events

    private void OnEnable()
    {
        inputs.Enable();
        shootAction.action.performed += OnShootPerformed;
    }

    private void OnDisable()
    {
        inputs.Disable();
        shootAction.action.performed -= OnShootPerformed;
    }

    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        if (context.performed) Debug.Log("Shoot");
    }

    #endregion
}
