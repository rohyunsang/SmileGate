using UnityEngine;
using UnityEngine.Video;

public class TutorialManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip clip;
    public GameObject tutorialPanel;
    private PlayerController pc;

    private bool playFlag;
    private void Awake()
    {
        if (videoPlayer == null)
            videoPlayer = FindFirstObjectByType<VideoPlayer>();

        playFlag = false;
    }

    private void Start()
    {
        pc = MainManager.instance.playerController;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playFlag)
            return;
        if(collision.CompareTag("Player"))
        {
            playFlag = true;
            tutorialPanel.SetActive(true);
            videoPlayer.clip = clip;
            videoPlayer.Play();
            Time.timeScale = 0;
        }
    }
}
