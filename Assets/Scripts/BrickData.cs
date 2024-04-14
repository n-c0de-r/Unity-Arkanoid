using System;
using UnityEngine;

/// <summary>
/// Represents the data of a brick in the level.
/// </summary>
[Serializable]
[CreateAssetMenu(fileName = "Brick", menuName = "ScriptableObjects/Brick")]
public class BrickData : ScriptableObject
{
    #region Serialized Fields

    [Tooltip("The object to instanciate for this brick element.")]
    [SerializeField] private GameObject prefab;

    [Tooltip("The color of this brick element.")]
    [SerializeField] private Color color;

    [Tooltip("The number of hits this brick element takes before it is destroyed.")]
    [SerializeField][Range(1, 6)] private byte life;

    [Tooltip("Specifies if this brick element can destroyed.")]
    [SerializeField] private bool isDestructable;

    [Tooltip("The buff/nerf this brick element may give when destroyed.")]
    [SerializeField] private string possibleBuff, possibleNerf;

    #endregion


    #region GetSets

    public GameObject Prefab => prefab;
    public Color Color => color;
    public byte Life => life;
    public bool Destructable => isDestructable;
    public string Buff => possibleBuff;
    public string Nerf => possibleNerf;

    #endregion
}
