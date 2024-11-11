using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class AudioSlider : MonoBehaviour
{

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] AudioMixMode mixMode;
    [SerializeField] private Scrollbar scrollbar;
    public void OnChangeSlider(float value)
    {
        switch( mixMode )
        {
            case AudioMixMode.LinearAudioSourceVolume:
                audioSource.volume= value; break;
            case AudioMixMode.LinearMixerVolume:
                mixer.SetFloat("Master",(-80+value*100));
                PlayerPrefs.SetFloat("mainVolume",value);
                break;

            case AudioMixMode.LogrithmicMixerVolume:
                mixer.SetFloat("Volume", Mathf.Log10(value) * 20);break;
        }
    }
    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }
    public void Start()
    {
        if (!PlayerPrefs.HasKey("mainVolume"))
        {
            PlayerPrefs.SetFloat("mainVolume", 0);
        }
        scrollbar.value = PlayerPrefs.GetFloat("mainVolume");
        
    }
}
