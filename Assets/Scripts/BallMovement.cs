using UnityEngine;

/// <summary>
/// Responsible of the ball movement in game.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private Rigidbody2D ballBody;
    [SerializeField] [Range(1,5)] private float initialSpeed = 2.0f;
    [SerializeField][Range(5, 10)] private const float maxSpeed = 10;

    #endregion


    #region Unity Built-Ins

    private void Awake()
    {
        TryGetComponent(out ballBody);
        Shoot(Vector2.right + Vector2.up);
    }

    private void FixedUpdate()
    {
        if (ballBody.velocity.magnitude >= maxSpeed) ballBody.velocity = Vector2.ClampMagnitude(ballBody.velocity, maxSpeed);
    }

    #endregion


    #region Methods

    /// <summary>
    /// Shoots the magic ball in a given direction.
    /// </summary>
    /// <param name="direction">The direction to shoot at.</param>
    public void Shoot(Vector2 direction)
    {
        ballBody.velocity = initialSpeed * direction;
    }

    #endregion

}
