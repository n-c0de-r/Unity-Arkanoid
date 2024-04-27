using UnityEngine;

public class LoseArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball ball))
        {
            ball.gameObject.SetActive(false);
            GameManager.OnBallLost.Invoke();
        }
    }
}
