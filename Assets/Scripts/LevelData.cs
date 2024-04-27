using System;
using UnityEngine;

/// <summary>
/// Represents the data of a level as a string.
/// Each row is a line separated by semicolons.
/// </summary>
[Serializable]
[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level")]
public class LevelData : ScriptableObject
{
    #region Serialized Fields

    [Tooltip("All rows of bricks in a level.\n" +
        "Each level consists of up to 6 rows.\n" +
        "Each row consists of up to 8 bricks.")]
    [TextArea(6, 10)]
    [SerializeField] private string data;

    [Tooltip("The background displayed on this level.")]
    [SerializeField] private Sprite background;

    #endregion


    #region GetSets

    public string Data => data;
    
    public string[] Rows => data.Split(';');

    public Sprite Back => background;

    #endregion
}
