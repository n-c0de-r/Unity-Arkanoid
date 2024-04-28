using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    #region Serialized Fields
    
    [SerializeField] private TMP_Text coinCounter;
    [SerializeField] private Slider enemyHealth;
    [SerializeField] private GameObject pauseMenu, menuPanel, volumePanel;
    [SerializeField] private Settings currentSettings;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider mainVolume, musicVolume, soundVolume;

    #endregion


    #region Built-Ins / MonoBehaviours

    private void Awake()
    {
        ResetAudio();
    }

    #endregion


    #region Methods

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

    /// <summary>
    /// Sets the in-game volume to a given value.
    /// </summary>
    /// <param name="volume">The volume to set to.</param>
    public void SetMainVolume(float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);
        currentSettings.MainVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        currentSettings.MusicVolume = volume;
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("SoundVolume", volume);
        currentSettings.SoundVolume = volume;
    }

    private void ResetAudio()
    {
        float main = currentSettings.MainVolume;
        float music = currentSettings.MusicVolume;
        float sound = currentSettings.SoundVolume;

        SetMainVolume(main);
        SetMusicVolume(music);
        SetSoundVolume(sound);

        mainVolume.value = main;
        musicVolume.value = music;
        soundVolume.value = sound;
    }

    #endregion
}
