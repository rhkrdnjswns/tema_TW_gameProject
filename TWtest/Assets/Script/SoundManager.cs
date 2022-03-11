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
    public void StopSound()//BGM 끄기, 씬 전환으로 BGM이 바뀌는 경우 끈 후에 오디오클립 바꿔주고 다시 틀어주기,,
    {
         bgm.Stop();
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
