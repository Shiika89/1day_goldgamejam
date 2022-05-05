using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType
{
    Title,
    Game,
    Result,
}
public enum SEType
{
   Shot,
   Hit,
   Start,
   End,
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    static SoundManager instance = default;
    const int MAX_VOLUME = 1;
    [SerializeField]
    AudioClip[] m_seClips = default;
    [SerializeField]
    AudioClip[] m_bgmClips = default;
    [SerializeField]
    AudioSource m_bgmSource = default;

    AudioSource m_audio = default;
    Dictionary<SEType, AudioClip> m_seDic = default;
    Dictionary<BGMType, AudioClip> m_bgmDic = default;
    bool m_isPlaying = false;
    [SerializeField]
    float m_bgmVolume = MAX_VOLUME / 2f;
    [SerializeField]
    float m_seVolume = MAX_VOLUME / 2f;

    public static BGMType CurrentBGM { get; private set; }
    public static float BGMVolume
    {
        get => instance.m_bgmVolume;
        set
        {
            if (value > MAX_VOLUME)
            {
                instance.m_bgmVolume = MAX_VOLUME;
            }
            else if (value < 0)
            {
                instance.m_bgmVolume = 0;
            }
            else { instance.m_bgmVolume = value; }
            instance.m_bgmSource.volume = instance.m_bgmVolume;
        }
    }
    public static float SEVolume
    {
        get => instance.m_seVolume;
        set
        {
            if (value > MAX_VOLUME)
            {
                instance.m_seVolume = MAX_VOLUME;
            }
            else if (value < 0)
            {
                instance.m_seVolume = 0;
            }
            else { instance.m_seVolume = value; }
            instance.m_audio.volume = instance.m_seVolume;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            m_audio = GetComponent<AudioSource>();
            m_seDic = new Dictionary<SEType, AudioClip>();
            m_bgmDic = new Dictionary<BGMType, AudioClip>();
            for (int i = 0; i < m_seClips.Length; i++)
            {
                m_seDic.Add((SEType)i, m_seClips[i]);
            }
            for (int i = 0; i < m_bgmClips.Length; i++)
            {
                m_bgmDic.Add((BGMType)i, m_bgmClips[i]);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Play(SEType type)
    {
        if (instance)
        {
            instance.m_audio.PlayOneShot(instance.m_seDic[type]);
            //Debug.Log(type);
        }
    }
    public static void PlayBGM(BGMType type, float fadeTime = 1f)
    {
        if (instance)
        {
            if (instance.m_isPlaying)
            {
                instance.ChangeBGM(type, fadeTime);
            }
            else
            {
                instance.SetBGM(type);
            }
        }
    }
    public static void StopBGM(float fadeTime = 1f)
    {
        if (instance)
        {
            instance.StartCoroutine(instance.FadeOutBGM(fadeTime));
        }
    }
    void SetBGM(BGMType type)
    {
        m_bgmSource.clip = m_bgmDic[type];
        m_bgmSource.Play();
        m_bgmSource.loop = true;
        CurrentBGM = type;
        m_isPlaying = true;
    }
    void ChangeBGM(BGMType type, float fadeTime)
    {
        if (type != CurrentBGM)
        {
            StartCoroutine(FadeChangeBGM(type, fadeTime));
        }
    }
    IEnumerator FadeChangeBGM(BGMType type, float fadeChangeTime)
    {
        float timer = 0f;
        while (timer < fadeChangeTime)
        {
            timer += Time.deltaTime;
            m_bgmSource.volume = m_bgmVolume * (1 - timer / fadeChangeTime);
            yield return null;
        }
        m_bgmSource.Stop();
        SetBGM(type);
        m_bgmSource.volume = m_bgmVolume;
    }
    IEnumerator FadeOutBGM(float fadeTime)
    {
        float timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            m_bgmSource.volume = m_bgmVolume * (1 - timer / fadeTime);
            yield return null;
        }
        m_bgmSource.Stop();
        m_bgmSource.volume = m_bgmVolume;
    }
}
