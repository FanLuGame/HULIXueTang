using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHelp : MonoBehaviour
{
    public AudioClip pao;
    public AudioClip wei;
    public AudioClip didi;
    public static SoundHelp instance;
    private void Awake()
    {
        instance = this;
    }
    public void PlaySound(float vo)
    {
        AudioSource.PlayClipAtPoint(pao, FindObjectOfType<AudioListener>().transform.position, vo);

    }
    public void PlaySound_w(float vo)
    {
        AudioSource.PlayClipAtPoint(wei, FindObjectOfType<AudioListener>().transform.position, vo);

    }
    public void PlaySound_di()
    {
        AudioSource.PlayClipAtPoint(didi, FindObjectOfType<AudioListener>().transform.position, 1);

    }
}
