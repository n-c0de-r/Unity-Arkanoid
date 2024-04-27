using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the given scene.
    /// </summary>
    /// <param name="scene">Scene Asset file.</param>
    public void LoadScene(SceneAsset scene)
        => SceneManager.LoadScene(scene.name);

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
}