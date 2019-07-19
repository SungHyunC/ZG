using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    #region 싱글톤
    private static SoundMgr _instance = null;

    public static SoundMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (SoundMgr)FindObjectOfType(typeof(SoundMgr));
                if (_instance == null)
                {
                    Debug.Log("There's no active ManagerClass object");
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            _instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }

        _Awake();
    }
    #endregion

    public AudioClip[] audioClip; // 오디오 소스들 지정.
    public Dictionary<string, AudioClip> audioClipsDic;
    AudioSource _AudioSource;


    void _Awake()
    {
        _AudioSource = GetComponent<AudioSource>();
        audioClipsDic = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in audioClip)
        {
            audioClipsDic.Add(a.name, a);
        }
    }

    // 한 번 재생 : 볼륨은 1 고정
    public void PlaySound(string a_name)
    {
        PlaySound(a_name, 1f);
    }

    // 한 번 재생 : 볼륨 매개변수로 지정
    public void PlaySound(string a_name, float a_volume)
    {
        if (audioClipsDic.ContainsKey(a_name) == false)
        {
            Debug.Log(a_name + " is not Contained audioClipsDic");
            foreach (KeyValuePair<string, AudioClip> pair in audioClipsDic)
            {
                Debug.Log(pair.Key + " " + pair.Value);
            }
            return;
        }
        _AudioSource.PlayOneShot(audioClipsDic[a_name], a_volume);
    }

    // 랜덤으로 한 번 재생 : 볼륨은 1 고정
    public void PlayRandomSound(string[] a_nameArray)
    {
        PlayRandomSound(a_nameArray, 1f);
    }

    // 랜덤으로 한 번 재생 : 볼륨 매개변수로 지정
    public void PlayRandomSound(string[] a_nameArray, float a_volume)
    {
        string l_playClipName;

        l_playClipName = a_nameArray[Random.Range(0, a_nameArray.Length)];

        if (audioClipsDic.ContainsKey(l_playClipName) == false)
        {
            Debug.Log(l_playClipName + " is not Contained audioClipsDic");
            return;
        }
        _AudioSource.PlayOneShot(audioClipsDic[l_playClipName], a_volume);
    }
}
