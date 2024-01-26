using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� BGM �� SE ����� ����մϴ�.
/// ����� ���� AudioSource�� �������� �����ǹǷ� �����ڴ� AudioSource�� �������� �ʾƵ� �˴ϴ�.
/// </summary>
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private Transform SE_tr;

    [SerializeField]
    private List<AudioSource> SE_audioList;

    [SerializeField]
    private AudioSource BGM_audio;


    public void Init()
    {
        SE_tr = this.transform.Find("SE_AudioBox");
        if (SE_tr == null)
        {
            Transform go = new GameObject("SE_AudioBox").transform;
            go.SetParent(this.transform);
            SE_tr = go;
        }

        SE_audioList = new List<AudioSource>();

        BGM_audio = this.GetComponent<AudioSource>();
        if (BGM_audio == null)
            BGM_audio = this.gameObject.AddComponent<AudioSource>();

        BGM_audio.volume = 0f;
        BGM_audio.loop = true;

        // ��� ���� ��� (�� Temp_BGM �� �ٸ� BGM�� �����ϼ���)
        PlayBGM("Temp_BGM", 1.5f);
    }


    /// <summary>
    /// BGM ������� ����ϴ� �Լ��̴�.
    /// </summary>
    /// <param name="BGM_name">����� BGM �̸� </param>
    /// <param name="fadeTime">Fade ��ȯ �ð�</param>
    public void PlayBGM(string BGM_name, float fadeTime)
    {
        AudioClip BGM_clip = GameManager.Resource.Load<AudioClip>($"Audios/BGM/{BGM_name}");
        PlayBGM(BGM_clip, fadeTime);
    }


    /// <summary>
    /// BGM ������� ����ϴ� �Լ��̴�.
    /// </summary>
    /// <param name="BGM_clip">����� BGM ����� Ŭ�� </param>
    /// <param name="fadeTime">Fade ��ȯ �ð�</param>
    public void PlayBGM(AudioClip BGM_clip, float fadeTime)
    {
        if (BGM_clip == null)
        {
            Debug.LogError("BGM ����� Ŭ���� NULL�Դϴ�!");
            return;
        }

        BGM_audio.Play();
        StartCoroutine(BGMFade(BGM_clip, fadeTime));
    }


    /// <summary>
    /// SE ������� ����ϴ� �Լ��̴�.
    /// </summary>
    /// <param name="SE_name">����� SE �̸�</param>
    public void PlaySE(string SE_name)
    {
        AudioClip SE_clip = GameManager.Resource.Load<AudioClip>($"Audios/SE/{SE_name}");
        PlaySE(SE_clip);
    }


    /// <summary>
    /// SE ������� ����ϴ� �Լ��̴�.
    /// </summary>
    /// <param name="SE_clip">����� SE ����� Ŭ��</param>
    public void PlaySE(AudioClip SE_clip)
    {
        if (SE_clip == null)
        {
            Debug.LogError("SE ����� Ŭ���� NULL�Դϴ�!");
            return;
        }

        AudioSource audio = FindIdleAudio();
        if (audio == null)
        {
            Debug.LogError("����� �ҽ��� NULL�Դϴ�!");
            return;
        }

        audio.clip = SE_clip;
        audio.Play();
    }


    /// <summary>
    /// ���� ��� ������ ����� �ҽ��� Ž���Ͽ� ��ȯ�ϴ� �Լ��̴�.
    /// </summary>
    private AudioSource FindIdleAudio()
    {
        foreach (var audio in SE_audioList)
            if (!audio.isPlaying)
                return audio;
        return CreateAudio();
    }


    /// <summary>
    /// ���ο� ����� �ҽ��� �����ϰ� ��ȯ�ϴ� �Լ��̴�.
    /// </summary>
    private AudioSource CreateAudio()
    {
        GameObject go = new GameObject();
        go.transform.SetParent(SE_tr);

        AudioSource source = go.AddComponent<AudioSource>();
        source.loop = false;
        source.playOnAwake = false;
        SE_audioList.Add(source);

        return source;
    }


    /// <summary>
    /// ����� ������ ������ ��ȯ��Ű�� �ڷ�ƾ �Լ��̴�.
    /// </summary>
    /// <param name="BGM_clip">����� BGM ����� Ŭ�� </param>
    /// <param name="fadeTime">Fade ��ȯ �ð�</param>
    IEnumerator BGMFade(AudioClip BGM_clip, float fadeTime)
    {
        while (BGM_audio.volume > 0f)
        {
            BGM_audio.volume -= Time.deltaTime / fadeTime;
            yield return null;
        }

        BGM_audio.volume = 0f;
        BGM_audio.clip = BGM_clip;

        while (BGM_audio.volume < 1f)
        {
            BGM_audio.volume += Time.deltaTime / fadeTime;
            yield return null;
        }

        BGM_audio.volume = 1f;
    }
}
