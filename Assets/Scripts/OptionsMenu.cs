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
    public Slider SFXAudio;
    public Slider MusicAudio;

    #endregion

    #region Audio Values

    public AudioSource MasterAudioSource;
    public AudioSource SFXAudioSource;
    public AudioSource MusicAudioSource;

    public AudioMixer MasterMixerGroup;
    public AudioMixer MusicGroup;
    public AudioMixer SFXGroupMusic;

    #endregion

    #region Buttons

    public GameObject OptionsMenuObject;
    public GameObject PauseMenu;

    #endregion



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


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


    public void SetSFXSound(float soundLevel)
    {

        SFXGroupMusic.SetFloat("SFXVolume", SFXAudio.value);

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
