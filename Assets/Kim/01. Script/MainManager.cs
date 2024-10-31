using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

    [Header("# Bone")]
    public Sprite oneBone;
    public Sprite twoBone;
    public Sprite threeBone;
    public Sprite fourBone;
    public Sprite fiveBone;
    private Image boneImage;


    private float finalScore;
    private float startTIme;
    private float scorePerSecond;

    private bool sceneLoadFlag;
    private TMP_Text text;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        scorePerSecond = 1;
        sceneLoadFlag = false;
        startTIme = 0;
        blueGhost = 0;
        greenGhost = 0;
        redGhost = 0;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (sceneLoadFlag)
            return;

        startTIme += Time.deltaTime;
        Debug.Log(startTIme);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (sceneLoadFlag)
            return;

        if(scene.name == "Result")
        {
            Debug.Log("씬이 로드되었습니다: " + scene.name);
            text = GameObject.FindWithTag("Score").GetComponent<TMP_Text>();
            boneImage = GameObject.FindWithTag("Bone").GetComponent<Image>();
            CalculateScore();
            sceneLoadFlag = true;
        }
    }

    void CalculateScore()
    {
        Debug.Log(distanceScore * Mathf.Ceil(startTIme) + "점(거리점수)");
        Debug.Log(blueGhost * 30 + "점(파랑유령)");
        Debug.Log(greenGhost * 50 + "점(초록유령)");
        Debug.Log(redGhost * 100 + "점(빨간유령)");

        Debug.Log("총 점수 : " + (distanceScore * Mathf.Ceil(startTIme) + blueGhost * 30 + greenGhost * 50 + redGhost * 100));
        finalScore = (distanceScore * Mathf.Ceil(startTIme) + blueGhost * 30 + greenGhost * 50 + redGhost * 100);
        text.text = finalScore.ToString() + " 점";
        CheckResult();
    }

    void CheckResult()
    {
        if (finalScore > four)
            boneImage.sprite = fiveBone;
        else if(finalScore > three)
            boneImage.sprite = fourBone;
        else if(finalScore > two)
            boneImage.sprite = threeBone;
        else if(finalScore > one)
            boneImage.sprite = twoBone;
        else
            boneImage.sprite = oneBone;
    }
}
