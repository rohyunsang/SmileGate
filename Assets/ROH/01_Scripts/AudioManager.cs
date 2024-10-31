using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton Pattern
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        Init();
    }
    #endregion


    public enum AudioType { BGM, SFX }

    [Header("#BGM")]
    public AudioClip[] bgmClips;                        // BGM Ŭ�� ������
    public float bgmVolume;
    AudioSource bgmPlayer;                              // BGM �÷��̾�� ����
                                                        // �������(BGM) Ŭ��
    public enum BGM
    {
        BGM_Lobby = 0,
        BGM_NormalStage1 = 1,
        BGM_NormalStage4 = 2,
        BGM_NormalStage5 = 3,
        BGM_NormalStage7 = 4,
        BGM_NormalStage8 = 5,
        BGM_NormalStage10 = 6,
        BGM_ChaosStage1 = 7,
        BGM_ChaosStage4 = 8,
        BGM_ChaosStage5 = 9,
        BGM_ChaosStage7 = 10,
        BGM_ChaosStage8 = 11,
        BGM_ChaosStage10 = 12,
    }

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;                                // SFX ���� ä��
    AudioSource[] sfxPlayers;                           // SFX�� ���ÿ� �������� �����
    int channelIndex;

    public enum SFX
    {
        // UI
        SFX_UI_ClickSound = 0,
        SFX_PurchaseSound = 1,
        SFX_StageFailSound = 2,
        SFX_StageClearSound = 3,
        SFX_BattleStartSound = 4,

        // Skills
        SFX_SkillSoundIncreaseAttack = 5,
        SFX_SkillSoundCannon = 6,
        SFX_SkillSoundMeteor = 7,
        SFX_SkillSoundRanged = 8,
        SFX_SkillSoundHeal = 9,

        // Basic actions
        SFX_BasicAttackSound = 10,
        SFX_SlimeDeathSound = 11,
        SFX_ObjectAttackSound = 12,
        SFX_ObjectOpenSound = 13,
        SFX_EnemyDeathSound = 14,
        SFX_BowShootSound = 15,

        // ����Ʈ
        SFX_None = 16
    }

    public float BGMVolume
    {
        get => GetVolume(AudioType.BGM);
        set => OnVolumeChanged(AudioType.BGM, value);
    }

    public float SFXVolume
    {
        get => GetVolume(AudioType.SFX);
        set => OnVolumeChanged(AudioType.SFX, value);
    }

    private void Init()
    {
        // ����� �÷��̾� �ʱ�ȭ
        GameObject bgmObject = new GameObject("BGMPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;                          // ���� ���� �� ��� ����
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;

        // �뷮 ����ȭ
        bgmPlayer.dopplerLevel = 0.0f;
        bgmPlayer.reverbZoneMix = 0.0f;
        //bgmPlayer.clip = bgmClips;

        // ȿ���� �÷��̾� �ʱ�ȭ
        GameObject sfxObject = new GameObject("SFXPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int idx = 0; idx < sfxPlayers.Length; idx++)
        {
            sfxPlayers[idx] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[idx].playOnAwake = false;
            sfxPlayers[idx].volume = sfxVolume;
            sfxPlayers[idx].dopplerLevel = 0.0f;
            sfxPlayers[idx].reverbZoneMix = 0.0f;
        }

        bgmVolume = 1.0f - PlayerPrefs.GetFloat("BGM_Volume");           // default ���� 0�̱� ������ 1.0f - value�� ����
        sfxVolume = 1.0f - PlayerPrefs.GetFloat("Effect_Volume");
    }

    // BGM ����� ���� �Լ�
    public void PlayBgm(BGM bgm)
    {
        if (bgmPlayer == null) return;
        bgmPlayer.clip = bgmClips[(int)bgm];
        bgmPlayer.Play();
    }

    public void StopBgm()
    {
        if (bgmPlayer != null) bgmPlayer.Stop();
    }

    // ȿ���� ����� ���� �Լ�
    public void PlaySfx(SFX sfx)
    {
        // ���� �ִ� �ϳ��� sfxPlayer���� clip�� �Ҵ��ϰ� ����
        for (int idx = 0; idx < sfxPlayers.Length; idx++)
        {
            int loopIndex = (idx + channelIndex) % sfxPlayers.Length;    // ä�� ������ŭ ��ȸ�ϵ��� ä���ε��� ���� Ȱ��

            if (sfxPlayers[loopIndex].isPlaying) continue;               // ���� ���� sfxPlayer�� �� ����

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }

    public void OnChangedBGMVolume(float value)
    {
        BGMVolume = value;
        bgmPlayer.volume = BGMVolume;
    }

    public float GetVolume(AudioType type)
    {
        return type == AudioType.BGM ? bgmPlayer.volume : sfxPlayers[0].volume;
    }

    public void OnVolumeChanged(AudioType type, float value)
    {
        PlayerPrefs.SetFloat(type == AudioType.BGM ? "BGM_Volume" : "SFX_Volume", 1.0f - value);

        if (type == AudioType.BGM)
        {
            bgmPlayer.volume = value;
        }
        else
        {
            foreach (var player in sfxPlayers)
            {
                player.volume = value;
            }
        }
    }
}