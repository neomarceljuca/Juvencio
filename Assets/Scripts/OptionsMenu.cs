using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    //public GameObject myVolumeText;
    //public AudioMixer audioMixer;

    [SerializeField] GameObject myTextSource;
    TextMeshProUGUI myText;

    void Start()
    {
        myText = myTextSource.GetComponent<TextMeshProUGUI>();
    }



    public void SetVolume(float volume)
    {
        //audioMixer.SetFloat("Volume", volume-80);
        // Debug.Log(volume);


        myText.text = volume + " ";
    }
}
