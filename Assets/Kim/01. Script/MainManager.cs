using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    [Header("# Manager")]
    public CameraController camController;
    public PlayerController playerController;

    [Header("# Score")]
    public int gameScore;
    public int distanceScore;
    public int blueGhost;
    public int greenGhost;
    public int redGhost;
    public int healthScore;

    [Header("# Criteria")]
    public int one;
    public int two;
    public int three;
    public int four;
    public int five;

    private float startTIme;
    private float scorePerSecond;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        scorePerSecond = 1;

        startTIme = 0;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        startTIme += Time.deltaTime;
        Debug.Log(startTIme);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Result")
        {
            Debug.Log("씬이 로드되었습니다: " + scene.name);

        }
    }
}
