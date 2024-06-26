using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the data of the game.
/// Linke scores, which level to play and how to spawn bricks
/// </summary>
public class GameManager : MonoBehaviour
{
    public static Action<uint> OnBrickHit;
    public static Action OnBrickDeath, OnBallLost;

    #region Serialized Fields

    [Header("Level related values")]

    [Tooltip("All levels of this game.")]
    [SerializeField] private LevelData[] levels;

    [Tooltip("The level's background image.")]
    [SerializeField] private BackgroundManager backgrounds;

    [Tooltip("The currently played level.")]
    [SerializeField][Range(1,9)] private byte currentLevel;


    [Space]
    [Header("Gameplay related objects")]

    [Tooltip("The game object playing the level music.")]
    [SerializeField] private AudioSource audioPlayer;

    [Tooltip("The game object holding all the brick elements.")]
    [SerializeField] private Transform brickContainer;

    [Tooltip("The game object representing a brick.")]
    [SerializeField] private GameObject brickPrefab;

    [Tooltip("The game object representing an indestructible block.")]
    [SerializeField] private GameObject blockPrefab;

    [Tooltip("The game object representing an angle.")]
    [SerializeField] private GameObject anglePrefab;

    [Tooltip("The game object representing a bouncer.")]
    [SerializeField] private GameObject bouncerPrefab;

    [Tooltip("The UI representation of scores.")]
    [SerializeField] private TMP_Text scoreCounter;

    [Tooltip("The UI representation of lifes.")]
    [SerializeField] private Slider life;


    [Space]
    [Header("Gameplay related information")]

    [Tooltip("The vector representing the spacing between bricks.")]
    [SerializeField] private Vector2 brickOffset;

    [Space]

    #endregion


    #region Fields

    private const byte NR_BLOCK_TYPES = 7;

    private byte _ballCounter = 3;

    private uint _score, _highScore;
    private byte _allBricks, _currentBricks;

    #endregion


    #region Unity Built-Ins

    // Start is called before the first frame update
    void Awake()
    {
        SetupLevel(levels[currentLevel-1]);
        OnBrickHit += UpdateScore;
        OnBrickDeath += UpdateBricks;
        OnBallLost += UpdateLife;
        life.value = _ballCounter;
    }

    #endregion
    
    
    #region Methods

    private void SetupLevel(LevelData levelData)
    {
        backgrounds.Next(levelData.Back);

        string[] rows = levelData.Rows;

        for (byte rowNr = 0; rowNr < rows.Length; rowNr++)
        {
            char[] bricks = rows[rowNr].Trim().ToCharArray();

            for (byte brickNr = 0; brickNr < bricks.Length; brickNr++)
            {
                switch (bricks[brickNr])
                {
                    case '-':
                        continue;
                        
                    // B for Blocking brick
                    case 'B':
                        SpawnElement(blockPrefab, rowNr, brickNr, 0, NR_BLOCK_TYPES);
                        break;
                    
                    // Bouncy ball, for speedup
                    case 'O':
                        SpawnElement(bouncerPrefab, rowNr, brickNr);
                        break;
                    
                    // Triangles to change direction
                    case '^':
                        SpawnElement(anglePrefab, rowNr, brickNr);
                        break;

                    case '<':
                        SpawnElement(anglePrefab, rowNr, brickNr, 90);
                        break;

                    case 'v':
                        SpawnElement(anglePrefab, rowNr, brickNr, 180);
                        break;

                    case '>':
                        SpawnElement(anglePrefab, rowNr, brickNr, 270);
                        break;
                    
                    // The actual colored bricks
                    default:
                        SpawnElement(brickPrefab, rowNr, brickNr, 0, (byte)(bricks[brickNr]-'0'));
                        _currentBricks++;
                        break;
                }

            }
        }
        _allBricks = _currentBricks;
        audioPlayer.Stop();
        audioPlayer.clip = levelData.Music;
        audioPlayer.Play();
    }

    private void SpawnElement(GameObject prefab, byte row, byte position, int rotation = 0, byte value = 0)
    {
        int positionFactor = 1;
        if (value == NR_BLOCK_TYPES) positionFactor = 2; // Block bricks are half the size, need a different positioning

        GameObject instance = Instantiate(prefab, brickContainer);

        instance.transform.position = (new Vector2(position * (instance.transform.localScale.x * positionFactor), -row * instance.transform.localScale.y - 0.1f * row) + (Vector2)brickContainer.transform.position) * brickOffset;

        // Only angles have a rotation value and need to be set.
        if (rotation != 0) instance.transform.eulerAngles = new Vector3Int(0, 0, rotation);

        // Setup a brick if it has the mathching component and the value is set (only bricks have life anyway)
        if ((value != 0 && value < NR_BLOCK_TYPES) && instance.TryGetComponent(out Brick brick)) brick.Setup(value);
    }

    

    private void UpdateScore(uint points)
    {
        _score += points;
        if (_score > _highScore) _highScore = _score;
        if (_score % 100000 == 0) UpdateLife(1);
        scoreCounter.text = "" + _score.ToString("D6");
    }

    private void UpdateBricks()
    {
        _currentBricks--;
        backgrounds.FadeAlpha((float)_currentBricks / _allBricks);

        if(_currentBricks == 0)
        {
            _score += (uint)(currentLevel * 1000);
            SetupLevel(levels[currentLevel]);
            currentLevel++;
        }
    }

    private void UpdateLife()
    {
        _ballCounter--;
        if (_ballCounter == 0) SceneManager.LoadScene(0);
        life.value = _ballCounter;
    }
    private void UpdateLife(byte lifeUp)
    {
        _ballCounter = (byte)Math.Clamp(_ballCounter+lifeUp, 1, 10);
        life.value = _ballCounter;
    }

    #endregion


    #region Unity Events

    private void OnDestroy()
    {
        OnBrickHit -= UpdateScore;
        OnBrickDeath -= UpdateBricks;
        OnBallLost -= UpdateLife;
    }

    #endregion
}
