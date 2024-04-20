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
        "Each level consists of up to 6 rows.\n" +
        "Each row consists of up to 8 bricks.")]
    [TextArea(6, 10)]
    [SerializeField] private string data;

    #endregion


    #region GetSets

    public string Data => data;
    
    public string[] Rows => data.Split(';');

    #endregion
}
