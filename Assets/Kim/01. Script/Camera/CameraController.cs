using Unity.Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public CinemachineVirtualCamera virtualCamera;

    private CinemachineBasicMultiChannelPerlin noise;
    public float shakeCameraGain = 10.0f;  // 새로 설정할 카메라 흔들림 수치

    private float originalGain; // 카메라 흔들림을 멈추기 위한 원래 카메라 노이즈 수치

    private void Awake()
    {
        if (instance == null)
            instance = this;

        CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    void Start()
    {
        if (noise != null)
        {
            originalGain = noise.FrequencyGain;
        }
    }

    public void ShakeCamera()
    {
        noise.FrequencyGain = shakeCameraGain;
    }

    public void StopShakeCamera()
    {
        noise.FrequencyGain = originalGain;
    }
}
