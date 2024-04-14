using UnityEngine;

/// <summary>
/// Responsible of the ball movement in game.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private Rigidbody2D _ballBody;

    #endregion

    #region Fields

    private const float MAX_SPEED = 15f;

    #endregion

    #region Unity Built-Ins

    private void Awake()
    {
        TryGetComponent(out _ballBody);
    }

    private void FixedUpdate()
    {
        if (_ballBody.velocity.magnitude > MAX_SPEED) _ballBody.velocity = Vector2.ClampMagnitude(_ballBody.velocity, MAX_SPEED);
    }

    #endregion
}
