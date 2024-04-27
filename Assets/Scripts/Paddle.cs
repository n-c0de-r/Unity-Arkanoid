using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private InputActionAsset inputs;
    [SerializeField] private InputActionReference shootAction;
    [SerializeField] private BallMovement ball;

    #endregion


    #region Fields



    #endregion


    #region Unity Built-Ins



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
        if (ball.gameObject.activeInHierarchy) return;
        ball.Shoot(gameObject.transform.position, Vector2.right + Vector2.up);
    }

    #endregion
}
