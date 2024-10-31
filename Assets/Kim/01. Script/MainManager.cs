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


    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
}
