using UnityEngine;

/// <summary>
/// The representation of basic ball functions.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    #region Serialized Fields

    [Tooltip("The sound played when the ball hits something.")]
    [SerializeField] private AudioSource sound;
    
    [Tooltip("The trail effect then the ball moves.")]
    [SerializeField] private ParticleSystem effect;

    #endregion


    #region Unity Built-Ins

    private void Awake()
    {
        TryGetComponent(out sound);
    }

    #endregion


    #region Unity Events

    private void OnCollisionEnter2D(Collision2D target)
    {
        sound.Play();
        if(target.gameObject.TryGetComponent(out Brick brick)) brick.Hit(1);
    }

    #endregion
}
