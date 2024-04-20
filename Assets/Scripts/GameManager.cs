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
    [SerializeField][Range(1,10)] private byte currentLevel;

    [Space]
    [Header("Gameplay related objects")]

    [Tooltip("The game object holding all the brick elements.")]
    [SerializeField] private Transform brickContainer;

    [Tooltip("The game object representing a brick.")]
    [SerializeField] private GameObject brickPrefab;

    [Tooltip("The game object representing an angle.")]
    [SerializeField] private GameObject anglePrefab;

    [Tooltip("The game object representing a bouncer.")]
    [SerializeField] private GameObject bouncerPrefab;

    [Space]
    [Header("Gameplay related information")]

    [Tooltip("The vector representing the spacing between bricks.")]
    [SerializeField] private Vector2 brickOffset;

    [Space]

    #endregion


    #region Fields

    private uint score, highScore;

    #endregion


    #region Unity Built-Ins

    // Start is called before the first frame update
    void Start()
    {
        SetupLevel(levels[currentLevel-1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion


    #region Methods

    private void SetupLevel(LevelData data)
    {
        string[] rows = data.Rows;

        for (int rowNr = 0; rowNr < rows.Length; rowNr++)
        {
            char[] bricks = rows[rowNr].Trim().ToCharArray();

            for (int brickNr = 0; brickNr < bricks.Length; brickNr++)
            {
                switch (bricks[brickNr])
                {
                    case '-':
                        continue;

                    case 'B':
                        SpawnBrick(rowNr, brickNr, 7, false);
                        break;

                    case 'O':
                        SpawnBouncer(rowNr, brickNr);
                        break;

                    case '^':
                        SpawnAngle(rowNr, brickNr);
                        break;

                    case '<':
                        SpawnAngle(rowNr, brickNr, 90);
                        break;

                    case 'v':
                        SpawnAngle(rowNr, brickNr, 180);
                        break;

                    case '>':
                        SpawnAngle(rowNr, brickNr, 270);
                        break;

                    default:
                        SpawnBrick(rowNr, brickNr, bricks[brickNr], true);
                        break;
                }
            }
        }
    }

    private void SpawnBrick(int row, int position, int brickValue, bool destructable)
    {
        GameObject instance = Instantiate(brickPrefab, brickContainer);
        instance.transform.position = (new Vector2(position * instance.transform.localScale.x, -row * instance.transform.localScale.y - 0.1f * row) + (Vector2)brickContainer.transform.position) * brickOffset;
        Brick brick = instance.GetComponent<Brick>();
        brick.Setup(brickValue, destructable);
    }

    private void SpawnAngle(int row, int position, int rotation = 0)
    {
        GameObject instance = Instantiate(anglePrefab, brickContainer);
        instance.transform.position = (new Vector2(position * instance.transform.localScale.x, -row * instance.transform.localScale.y - 0.1f * row) + (Vector2)brickContainer.transform.position) * brickOffset;
        instance.transform.eulerAngles = new Vector3Int(0, 0, rotation);
    }

    private void SpawnBouncer(int row, int position)
    {
        GameObject instance = Instantiate(bouncerPrefab, brickContainer);
        instance.transform.position = (new Vector2(position * instance.transform.localScale.x, -row * instance.transform.localScale.y - 0.1f * row) + (Vector2)brickContainer.transform.position) * brickOffset;
    }

    #endregion
}
