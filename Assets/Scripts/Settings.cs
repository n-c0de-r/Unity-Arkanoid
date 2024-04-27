using UnityEngine;

/// <summary>
/// Made by <see href="https://github.com/n-c0de-r" langword="n-c0de-r" />
/// </summary>
[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Settings", order = 2)]
public class Settings : ScriptableObject
{
    #region Fields

    [SerializeField] private int lives = 3, players = 1;
    [SerializeField] private Difficulty baseDifficulty;

    #endregion

    #region GetSets

    /// <summary>
    /// The Lives a player has to play the game.
    /// Ranges from 0-9.
    /// </summary>
    public int Lives
    {
        get => lives;
        set => lives = Mathf.Clamp(value, 0, 9);
    }

    /// <summary>
    /// The number of players playing the game together.
    /// Ranges from 1-4.
    /// </summary>
    public int Players
    {
        get => players;
        set => players = Mathf.Clamp(value, 1, 4);
    }

    public Difficulty BaseDifficulty { get => baseDifficulty; set => baseDifficulty = value; }

    #endregion
}
