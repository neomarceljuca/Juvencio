using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer myMasterAudioMixer;
    public AudioMixer mySFXAudioMixer;
    public AudioMixer mySTAudioMixer;


    public TextMeshProUGUI textMeshMaster;
    public TextMeshProUGUI textMeshSFX;
    public TextMeshProUGUI textMeshST;

    public Slider mySliderMaster;
    public Slider mySliderSFX;
    public Slider mySliderST;

    void Start()
    {
        // MASTER VOLUME VARIABLES
        //volume range in Mastermixer goes from -80 to 20


        float volumeOnStart;
        myMasterAudioMixer.GetFloat("MasterVolume", out volumeOnStart);
        
        mySliderMaster.value = Mathf.Pow(10, volumeOnStart / 20);
        textMeshMaster.text = (int)(mySliderMaster.value * 100) + " ";

        // SOUND EFFECTS VARIABLES
        float SFXvolumeOnStart;
        mySFXAudioMixer.GetFloat("SFXVolume", out SFXvolumeOnStart);
        mySliderSFX.value = Mathf.Pow(10, SFXvolumeOnStart / 20);
        textMeshSFX.text = (int)(mySliderSFX.value * 100) + " ";

        // SOUNDTRACK VARIABLES
        float STvolumeOnStart;
        mySTAudioMixer.GetFloat("STVolume", out STvolumeOnStart);
        mySliderST.value = Mathf.Pow(10, STvolumeOnStart / 20);
        textMeshST.text = (int)(mySliderST.value * 100) + " ";
           


    }

    public void SetMasterVolume(float volume)
    {
        myMasterAudioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
       

        textMeshMaster.text = (int)(volume * 100) + " ";
    }

    public void SetSFXVolume(float volume)
    {
        mySFXAudioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);


        textMeshSFX.text = (int)(volume * 100) + " ";
    }

    public void SetSoundtrackVolume(float volume)
    {
        mySTAudioMixer.SetFloat("STVolume", Mathf.Log10(volume) * 20);


        textMeshST.text = (int)(volume*100) + " ";
    }


}