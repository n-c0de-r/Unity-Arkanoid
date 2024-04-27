using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    #region Serialized Fields

    [Tooltip("The level's background image.")]
    [SerializeField] private SpriteRenderer previous, current;

    #endregion

    #region Methods

    public void Next(Sprite newSprite)
    {
        if (current.sprite != null) previous.sprite = current.sprite;
        current.sprite = newSprite;

        current.color = Color.clear;
    }

    public void FadeAlpha(float value)
    {
        float factored = value * 1.5f;
        float reverse = 1 - value;
        previous.color = new Color(factored, factored, factored, factored);
        current.color = new Color(reverse, reverse, reverse, reverse);
    }

    #endregion
}
