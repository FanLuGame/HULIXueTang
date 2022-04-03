using System;
using UnityEngine;

public partial class MicrophoneManager : MonoBehaviour
{
    private static MicrophoneManager m_instance;

    private static string[] micArray = null; //录音设备列表
    public AudioClip audioClip;

    public float volum=1;
    const int HEADER_SIZE = 44;
    public int RECORD_TIME = 20;
    public int RECORD_RATE = 44100; //录音采样率


    private void Awake()
    {
        micArray = Microphone.devices;
        if (micArray.Length == 0)
        {
            Debug.LogError("no mic device");
        }
        foreach (string deviceStr in Microphone.devices)
        {
            Debug.Log("device name = " + deviceStr);
        }
    }
    /// <summary>
    /// 开始录音
    /// </summary>
    public void StartRecord()
    {
        if (micArray.Length == 0)
        {
            Debug.Log("No Record Device!");
            return;
        }
        Microphone.End(null);//录音时先停掉录音，录音参数为null时采用默认的录音驱动

        audioClip = Microphone.Start(null, false, RECORD_TIME, RECORD_RATE);
        while (!(Microphone.GetPosition(null) > 0))
        {
        }
        Debug.Log("StartRecord");
    }

    /// <summary>
    /// 停止录音并存储
    /// </summary>
    public void StopRecord()
    {
        if (micArray.Length == 0)
        {
            Debug.Log("No Record Device!");
            return;
        }
        if (!Microphone.IsRecording(null)) 
        {
            return;
        }
        Microphone.End(null);
        Save(filename);
        Debug.Log("StopRecord");
    }

    /// <summary>
    ///播放录音/存储的录音
    /// </summary>
    public void PlayRecord()
    {
        if (audioClip == null)
        {
            Debug.Log("audioClip is null.try to read");
            if (filename != "")
            {
                audioClip = Read(Application.persistentDataPath + "/" + filename);
                if (audioClip==null)
                {
                    return;
                }
                AudioSource.PlayClipAtPoint(audioClip, FindObjectOfType<AudioListener>().transform.position, volum);
                Debug.Log("PlayRecord");
            }
            return;
        }
        AudioSource.PlayClipAtPoint(audioClip, FindObjectOfType<AudioListener>().transform.position, volum);
        Debug.Log("PlayRecord");
    }


    public byte[] Save()
    {
        if (audioClip == null) return null;
        return WavUtility.FromAudioClip(audioClip);
    }

    public void Save( string filename)
    {
        Save(audioClip, filename);
    }

    public void Save(AudioClip clip, string filename)
    {
        if (clip == null)
        {
            Debug.Log("clip is null");

            return;
        }
        WavUtility.FromAudioClip(clip,true,filename);
    }

    public AudioClip Read(string path)
    {
        return WavUtility.ToAudioClip(path);
    }

    public AudioClip Read(byte[] data)
    {
        return WavUtility.ToAudioClip(data);
    }

    public string filename = "";
    /**
    private void OnGUI()
    {
        GUILayout.BeginVertical();
        filename= GUILayout.TextField(filename);
        if (ShowGUIButton("开始录音"))
        {
            StartRecord();
        }
        if (ShowGUIButton("停止录音并存储"))
        {
            StopRecord();
        }
        if (ShowGUIButton("播放录音"))
        {
            PlayRecord();
        }
        if (ShowGUIButton("读取"))
        {
            audioClip=Read(Application.persistentDataPath+"/"+filename);
        }
        if (ShowGUIButton("保存"))
        {
            Save(filename);
        }
        GUILayout.EndVertical();
    }*/

    bool ShowGUIButton(string buttonName)
    {
        return GUILayout.Button(buttonName, GUILayout.Height(Screen.height / 20), GUILayout.Width(Screen.width / 5));
    }
    //public JObject SaveAudioClip()
    //{
    //    JObject jd = new JObject();
    //    jd["time"] = beginTime.ToString("yyMMdd-HHmmss-fff");
    //    //jd["time"] = beginTime.ToFileTime();
    //    //使用Unicode编码，其他编码格式会有问题
    //    jd["audioclip"] = Encoding.Unicode.GetString(Save());
    //    return jd;
    //}
}