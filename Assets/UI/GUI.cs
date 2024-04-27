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


    private void Update()
    {
        coinCounter.text = GameData.gold.ToString();
        enemyHealth.value = GameData.enemyLives;
        if (GameData.life <= 0)
        {
            PauseGame();
        }
    }

    /// <summary>
    /// Pausemenu script parts by <see href="https://github.com/boTimPact"/>
    /// </summary>
    public void PauseGame()
    {
        GameData.isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        GameData.isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
        ResumeGame();
    }

    public void TogglePlay(bool running)
    {
        GameData.Reset();
        GameData.isRunning = running;
    }
}
