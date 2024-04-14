using System;
using UnityEngine;

/// <summary>
/// Represents the data of a level as a 2D collection.
/// Contains an array of <see cref="Row" />s
/// </summary>
[Serializable]
[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level")]
public class LevelData : ScriptableObject
{
    #region Serialized Fields

    [Tooltip("All rows of bricks in a level.\n" +
        "Each level consists of up to 6 rows.")]
    [SerializeField] private Row[] rows;

    #endregion


    #region GetSets

    public Row[] Rows { get => rows; }

    #endregion


    #region InnerStructs

    /// <summary>
    /// Represents the row of <see cref="BrickData" />.
    /// </summary>
    [Serializable]
    public struct Row
    {
        [Tooltip("All bricks in a row.\n" +
        "Each row consists of up to 8 bricks.")]
        [SerializeField] private BrickData[] bricks;
        public readonly BrickData[] Bricks { get => bricks; }
    }

    #endregion
}
