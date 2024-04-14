using UnityEngine;

/// <summary>
/// Manages the data of the game.
/// Linke scores, which level to play and how to spawn bricks
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Serialized Fields

    [Tooltip("All levels of this game.")]
    [SerializeField] private LevelData[] levels;

    [Tooltip("The currently played level.")]
    [SerializeField] private uint currentLevel;

    #endregion


    #region Fields

    private uint score, highScore;

    #endregion


    #region Unity Built-Ins

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
