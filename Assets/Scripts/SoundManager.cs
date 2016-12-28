using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource[] source;

    //public AudioClip[] clips;



    public static SoundManager instance;

    public void Awake()
    {
        instance = this;

    }

    public void Update()
    {
        //print(bgmSource.timeSamples);
        if (bgmSource.timeSamples >= 1150800 && bgmSource.timeSamples <= 1153800 && GameManager.instance.isGameOver == false)
        {
            for (int i = 0; i < 2; ++i)
                BubblePooling.instance.Spawn();
        }
        if (bgmSource.timeSamples >= 1990000 && bgmSource.timeSamples <= 1993000 && GameManager.instance.isGameOver == false)
        {
            for (int i = 0; i < 2; ++i)
                BubblePooling.instance.Spawn();
        }
        if (bgmSource.timeSamples >= 3736000 && bgmSource.timeSamples <= 3739000 && GameManager.instance.isGameOver == false)
        {
            for (int i = 0; i < 3; ++i)
                BubblePooling.instance.Spawn();
        }
    }

    public void SetAudioEnable(bool enable)
    {
        FindObjectOfType<AudioListener>().enabled = enable;
    }

    public void PlayBgm()
    {
        bgmSource.Play();
    }

    public void PlaySound(int index, float pitch = 1, float maxPitch = 3)
    {
        if (pitch > maxPitch)
            pitch = maxPitch;
        source[index].pitch = pitch;
        source[index].PlayOneShot(source[index].clip);
    }

    public void FadeOutBgm(float duration)
    {
        StartCoroutine(fadeOutBgm(duration));
    }

    public IEnumerator fadeOutBgm(float duration)
    {
        float tmp = bgmSource.volume / duration;
        float time = 0;
        while (time < duration)
        {
            bgmSource.volume -= tmp * Time.deltaTime;
            yield return null;
        }
        bgmSource.volume = 0;
    }
}
