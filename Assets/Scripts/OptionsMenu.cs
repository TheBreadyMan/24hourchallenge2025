using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{


    #region Player Sliders

    public Slider MasterAudio;
    public Slider VFXAudio;
    public Slider MusicAudio;

    #endregion

    #region Audio Values

    public AudioSource MasterAudioSource;
    public AudioSource VFXAudioSource;
    public AudioSource MusicAudioSource;

    public AudioMixer MasterMixerGroup;
    public AudioMixer MusicGroup;
    public AudioMixer VFXGroupMusic;

    #endregion

    #region Buttons

    public GameObject OptionsMenuObject;
    public GameObject PauseMenu;

    #endregion



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        MasterAudio.maxValue = 1;
        MusicAudio.maxValue = 1;
        VFXAudio.maxValue = 1;


        MasterAudio.minValue = 0;
        MusicAudio.minValue = 0;
        VFXAudio.minValue = 0;

    }

    #region Setting Sound

    public void SetMasterSound(float soundLevel)
    {

        MasterMixerGroup.SetFloat("MasterVolume", MasterAudio.value);
        

    }

    public void SetMusicSound(float soundLevel)
    {

        MusicGroup.SetFloat("MusicVolume", MusicAudio.value);

    }


    public void SetVFXSound(float soundLevel)
    {

        VFXGroupMusic.SetFloat("VFXVolume", VFXAudio.value);

    }


    #endregion

    #region Button Functions

    public void BackToResume()
    {

        PauseMenu.SetActive(true);
        OptionsMenuObject.SetActive(false);

    }


    public void Quit()
    {

        Application.Quit();

    }


    #endregion  









}
