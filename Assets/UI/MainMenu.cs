using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void LoadScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    /// <summary>
    /// Quits the application or editor.
    /// </summary>
    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }

    public void TogglePlay(bool running)
    {
        GameData.Reset();
        GameData.isRunning = running;
    }
}