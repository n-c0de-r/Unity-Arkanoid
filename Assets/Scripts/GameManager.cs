using UnityEngine;

/// <summary>
/// Manages the data of the game.
/// Linke scores, which level to play and how to spawn bricks
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Serialized Fields
    [Header("Level related values")]

    [Tooltip("All levels of this game.")]
    [SerializeField] private LevelData[] levels;

    [Tooltip("The currently played level.")]
    [SerializeField][Range(1,99)] private byte currentLevel;

    [Space]
    [Header("Gameplay related objects")]

    [SerializeField] private Transform brickContainer;

    [Space]

    #endregion


    #region Fields

    private uint score, highScore;

    #endregion


    #region Unity Built-Ins

    // Start is called before the first frame update
    void Start()
    {
        SpawnBricks(levels[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion


    #region Methods

    private void SpawnBricks(LevelData data)
    {
        for (int i = 0; i < data.Rows.Length; i++)
        {
            int midPoint = data.Rows[i].Bricks.Length / 2;

            for (int j = -midPoint; j < midPoint; j++)
            {
                BrickData piece = data.Rows[i].Bricks[j+midPoint];
                GameObject brick = Instantiate(piece.Prefab, brickContainer);
                brick.transform.position = new Vector2((j * brick.transform.localScale.x), (5-i * 2 * brick.transform.localScale.y) - brick.transform.localScale.y/2 - 0.1f);
                brick.GetComponent<SpriteRenderer>().color = piece.Color;
            }
        }
    }
    #endregion
}
