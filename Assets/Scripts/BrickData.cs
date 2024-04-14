using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Brick", menuName = "ScriptableObjects/Brick")]
public class BrickData : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Color color;
    [SerializeField][Range(1, 6)] private uint life;
    [SerializeField] private bool isDestructable;
    [SerializeField] private string possibleBuff, possibleNerf;
}
