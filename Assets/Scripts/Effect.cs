using UnityEngine;

/// <summary>
/// An object that takes care of playing particles and sounds on hits.
/// Created to play while the original brick is destroyed, if needed.
/// </summary>
public class Effect : MonoBehaviour
{
    #region Serialized Fields

    [Tooltip("The smaller particles emitted on sprite hit.")]
    [SerializeField] private ParticleSystem brickletParticles;

    [Tooltip("The bigger particles emitted on destroy.")]
    [SerializeField] private ParticleSystem explosionParticles;

    [Tooltip("The sound emitted on sprite hit.")]
    [SerializeField] private AudioSource sound;

    #endregion


    #region Unity Built-Ins

    private void Update()
    {
        if (brickletParticles.gameObject.activeSelf && !brickletParticles.IsAlive() && !sound.isPlaying) Destroy(gameObject);
        if (explosionParticles.gameObject.activeSelf && !explosionParticles.IsAlive() && !sound.isPlaying) Destroy(gameObject);
    }

    #endregion


    #region Methods

    /// <summary>
    /// Sets up the effect parameters.
    /// </summary>
    /// <param name="position">The position of the original brick.</param>
    /// <param name="color">The color of the original brick.</param>
    public void Setup(Vector3 position, Color color)
    {
        transform.position = position;
        ParticleSystem.MainModule bricklets = brickletParticles.main;
        ParticleSystem.MainModule explosion = explosionParticles.main;
        bricklets.startColor = color;
        explosion.startColor = color;
    }

    /// <summary>
    /// Plays the small particles on a hit.
    /// </summary>
    public void Bricklets()
    {
        brickletParticles.gameObject.SetActive(true);
    }

    /// <summary>
    /// Plays the big particles on destroy.
    /// </summary>
    public void Explode()
    {
        explosionParticles.gameObject.SetActive(true);
    }

    #endregion
}
