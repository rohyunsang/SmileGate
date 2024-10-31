using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton Pattern
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion


    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }






    public void OnApplicationQuit()
    {
        // App Quit
        Application.Quit();

#if UNITY_EDITOR
        // Editor Quit
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
