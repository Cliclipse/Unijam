using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSfx;
    [SerializeField] private AudioMixer mixer;
    
    // Start is called before the first frame update
    private void Awake()
    { 
        mixer.GetFloat("mainVolume",out float mainVolume);
        sliderMaster.value = Mathf.Exp(mainVolume/20f) ;
        mixer.GetFloat("musicVolume",out float musicVolume);
        sliderMusic.value = Mathf.Exp(musicVolume/20f);
        mixer.GetFloat("sfxVolume",out float sfxVolume);
        sliderSfx.value = Mathf.Exp(sfxVolume/20f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnmainVolumeChanged()
    {
        mixer.SetFloat("masterVolume", Mathf.Log(sliderMaster.value)*20f);
    }
    public void OnmusicVolumeChanged()
    {
        mixer.SetFloat("musicVolume", Mathf.Log(sliderMusic.value)*20f);
    }
    public void OnsfxVolumeChanged()
    {
        mixer.SetFloat("sfxVolume", Mathf.Log(sliderSfx.value)*20f);
    }
}
