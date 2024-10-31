using Unity.VisualScripting;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    [Header("# Manager")]
    public CameraController camController;
    public PlayerController playerController;

    [Header("# Score")]
    public int gameScore;

    private float startTIme;


    private void Awake()
    {
        if(instance == null)
            instance = this;

        startTIme = 0;
    }

    private void Update()
    {
        startTIme += Time.deltaTime;
        Debug.Log(startTIme);
    }
}
