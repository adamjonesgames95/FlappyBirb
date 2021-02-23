using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;

    void Start()
    {
        musicSlider.value = GlobalControl.CurrentMusicVolume;
        SFXSlider.value = GlobalControl.CurrentSFXVolume;
    }

    void Update()
    {
        GlobalControl.CurrentMusicVolume = musicSlider.value;
        GlobalControl.CurrentSFXVolume = SFXSlider.value;
    }
}
