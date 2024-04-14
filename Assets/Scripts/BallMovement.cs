using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _ballBody;
    private const float MAX_SPEED = 15f;

    private void Awake()
    {
        if (_ballBody == null) _ballBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_ballBody.velocity.magnitude > MAX_SPEED) _ballBody.velocity = Vector2.ClampMagnitude(_ballBody.velocity, MAX_SPEED);
    }
}
