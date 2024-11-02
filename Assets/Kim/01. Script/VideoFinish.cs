using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoFinish : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // VideoPlayer 컴포넌트

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // 비디오 끝에 도달했을 때 호출될 이벤트 등록
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // 비디오가 끝날 때 호출되는 메서드
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("Kim");
    }

    void OnDisable()
    {
        // 이벤트 해제
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
