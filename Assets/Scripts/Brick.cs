using UnityEngine;

public class Brick : MonoBehaviour
{
    #region Fields

    [Tooltip("The object to instanciate for this brick element.")]
    [SerializeField] private SpriteRenderer sprite;

    [Tooltip("The available colors for the brick elements.")]
    [SerializeField] private Color[] colors;

    [Tooltip("The number of hits this brick element takes before it is destroyed.")]
    private byte life;

    [Tooltip("Specifies if this brick element can destroyed.")]
    private bool isDestructable;

    [Tooltip("The buff/nerf this brick element may give when destroyed.")]
    [SerializeField] private string possibleBuff, possibleNerf;

    #endregion

    #region Unity Built-Ins

    private void Awake()
    {
        TryGetComponent(out sprite);
    }

    private void FixedUpdate()
    {
        
    }

    #endregion

    #region Methods

    public void Setup(int brickLife, bool destructable = false)
    {
        life = (byte)brickLife;
        isDestructable = destructable;
        sprite.color = colors[brickLife % colors.Length];
    }

    #endregion
}
