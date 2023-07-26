using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Slider bgmSlider = null;
    public Slider SFXSlider = null;

    void Start()
    {
        LoadVolume();
    }

    public void SettingVolume()
    {
        float bgmVolume = bgmSlider.value;
        audioMixer.SetFloat("Master", bgmVolume);
        PlayerPrefs.SetFloat("Master", bgmVolume);

        float SFXVolume = SFXSlider.value;
        audioMixer.SetFloat("SFXPrami", SFXVolume);
        PlayerPrefs.SetFloat("SFXPrami", SFXVolume);
    }

    public void LoadVolume()
    {
        float bgmLoadVolume = PlayerPrefs.GetFloat("Master");
        float SFXLoadVolume = PlayerPrefs.GetFloat("SFXVolume");
    }


}
