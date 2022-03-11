using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour
{
    public Slider BGMVolumebar;
    public Slider EffectVolumebar;

    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider effectSlider;



    /* public AudioSource BGM;     //static으로 선언해도 될듯
     public AudioSource Effect;

     private float BGMVol = 1f;
     private float EffectVol = 1f;*/
    private void Awake()
    {
        bgmSlider.value = 1;
        effectSlider.value = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        /*BGMVol = PlayerPrefs.GetFloat("BGMVol", 1f);
        EffectVol = PlayerPrefs.GetFloat("EffectVol", 1f);

        BGMVolumebar.value = BGMVol;
        BGM.volume = BGMVolumebar.value;

        EffectVolumebar.value = EffectVol;
        Effect.volume = EffectVolumebar.value;*/
    }

    // Update is called once per frame
    /*void Update()
    {
        SoundSlider();
    }
    public void SoundSlider()
    {
        BGM.volume = BGMVolumebar.value;
        BGMVol = BGMVolumebar.value;
        PlayerPrefs.SetFloat("BGMVol", 1f);

        Effect.volume = EffectVolumebar.value;
        EffectVol = EffectVolumebar.value;
        PlayerPrefs.SetFloat("EffectVol", 1f);
    }*/
    public void SetVoluem_BGM()
    {
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.VolumeSetting(true, bgmSlider.value);
        }
        
        
    }
    public void SetVoluem_Effect()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.VolumeSetting(false, effectSlider.value);
        }
    }
}
