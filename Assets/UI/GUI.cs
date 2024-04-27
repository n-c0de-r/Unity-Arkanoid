using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField] private TMP_Text coinCounter;
    [SerializeField] private Slider enemyHealth;
    [SerializeField] private GameObject pauseMenu;

    /// <summary>
    /// Pausemenu script parts by <see href="https://github.com/boTimPact"/>
    /// </summary>
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Loads the given scene.
    /// </summary>
    /// <param name="scene">Scene Asset file.</param>
    public void LoadScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }
}
