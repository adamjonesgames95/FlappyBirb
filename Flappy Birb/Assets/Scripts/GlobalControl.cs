using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public static int currentScore;

    public static float CurrentMusicVolume { get; set; }
    public static float CurrentSFXVolume { get; set; }
    public static int Difficulty { get; set; }

    public AudioSource musicAudio;
    public AudioSource jumpAudio;
    public AudioSource crashAudio;

    void Awake()
    {

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //CurrentMusicVolume = 1;
        //CurrentSFXVolume = 1;

        musicAudio.volume = CurrentMusicVolume;
        jumpAudio.volume = CurrentSFXVolume;
        crashAudio.volume = CurrentSFXVolume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

       musicAudio.volume = CurrentMusicVolume;
       jumpAudio.volume = CurrentSFXVolume;
       crashAudio.volume = CurrentSFXVolume;
    }

    public void IncrementScore()
    {
        currentScore += 1 ;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

}