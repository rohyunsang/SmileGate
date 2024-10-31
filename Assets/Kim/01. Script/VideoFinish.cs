using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoFinish : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // VideoPlayer ������Ʈ

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // ���� ���� �������� �� ȣ��� �̺�Ʈ ���
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // ������ ���� �� ȣ��Ǵ� �޼���
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("Kim");
    }

    void OnDisable()
    {
        // �̺�Ʈ ����
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
