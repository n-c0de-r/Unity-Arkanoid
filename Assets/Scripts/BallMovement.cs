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
    [SerializeField] [Range(5, 10)] private const float maxSpeed = 10;

    #endregion


    #region Fileds

    #endregion


    #region Unity Built-Ins

    private void Awake()
    {
        TryGetComponent(out ballBody);
    }

    private void FixedUpdate()
    {
        if (ballBody.velocity.magnitude >= maxSpeed) ballBody.velocity = Vector2.ClampMagnitude(ballBody.velocity, maxSpeed);
    }

    #endregion


    #region Methods

    /// <summary>
    /// Shoots the ball in a given direction.
    /// </summary>
    /// <param name="startPosition">The position where the shot starts.</param>
    /// <param name="direction">The direction of shooting.</param>
    public void Shoot(Vector2 startPosition, Vector2 direction)
    {
        gameObject.transform.position = startPosition + new Vector2(0, 0.5f);
        ballBody.velocity = Vector2.zero;
        gameObject.SetActive(true);
        ballBody.velocity = initialSpeed * direction;
    }

    #endregion

}
