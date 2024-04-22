using UnityEngine;

/// <summary>
/// The main object of the game.
/// Bricks lose power on hits, and are destroyed when power is at zero.
/// </summary>
public class Brick : MonoBehaviour
{
    #region Serialized Fields

    [Tooltip("The object to instanciate for this brick element.")]
    [SerializeField] private SpriteRenderer sprite;

    [Tooltip("The overlay symbol for this brick element.")]
    [SerializeField] private SpriteRenderer symbol;

    [Tooltip("The available colors for the brick elements.")]
    [SerializeField] private Color[] colors;

    [Tooltip("The available symbols for the brick elements.")]
    [SerializeField] private Sprite[] symbols;

    [Tooltip("The effects to play on sprite hit.")]
    [SerializeField] private GameObject effect;

    [Tooltip("The buff/nerf this brick element may give when destroyed.")]
    [SerializeField] private string possibleBuff, possibleNerf;

    #endregion


    #region Fields

    // Amount of score given on a hit
    private const uint BASE_SCORE = 50;

    [Tooltip("The amount of score this brick gives when it is destroyed.")]
    private uint _brickScore;

    [Tooltip("The number of hits this brick element takes before it is destroyed.")]
    private byte _brickLife;

    #endregion


    #region Unity Built-Ins

    private void Awake()
    {
        TryGetComponent(out sprite);
    }

    #endregion


    #region Methods

    /// <summary>
    /// Sets the initial life, symbol and color of a brick.
    /// </summary>
    /// <param name="life"></param>
    public void Setup(byte life)
    {
        Color color = colors[life];

        _brickScore = life * BASE_SCORE;
        _brickLife = life;
        sprite.color = color;
        symbol.sprite = symbols[life-1];
        symbol.color = color;
    }

    /// <summary>
    /// Deals damage to the brick and plays animations accordingly.
    /// </summary>
    /// <param name="damage">The damage amount dealt by the ball.</param>
    public void Hit(byte damage)
    {
        GameObject hit = Instantiate(effect, gameObject.transform.parent);
        hit.TryGetComponent(out Effect particles);
        particles.Setup(gameObject.transform.position, sprite.color);

        _brickLife -= damage;

        if (_brickLife <= 0)
        {
            particles.Explode();
            GameManager.OnBrickHit.Invoke(_brickScore);
            GameManager.OnBrickDeath.Invoke(1);

            Destroy(gameObject);
            return;
        }

        particles.Bricklets();
        GameManager.OnBrickHit.Invoke(damage * BASE_SCORE);

        Color color = colors[_brickLife];
        sprite.color = color;
        symbol.color = color;
        symbol.sprite = symbols[_brickLife - 1];
    }

    #endregion


    #region Unity Events

    private void OnDestroy()
    {
        
    }

    #endregion
}
