using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    [SerializeField] private AudioClip[] audioClips;

    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource effect;

    
    public static SoundManager Instance { get => instance;}
    public AudioSource Bgm { get => bgm; set => bgm = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public void PlaySound(bool isBGM, int index)
    {
        if (isBGM)
        {
            bgm.clip = audioClips[index];
            bgm.Play();
        }
        else
        {
            effect.clip = audioClips[index];
            effect.Play();
        }
    }
    public void VolumeSetting(bool isBGM, float value)
    {
        if (isBGM)
        {
            bgm.volume = value;
        }
        else
        {
            effect.volume = value;
        }
    }
}
