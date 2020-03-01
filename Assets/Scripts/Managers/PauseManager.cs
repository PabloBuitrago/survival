using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

    public Slider MusicVolumeSlider;
    public Slider FXVolumeSlider;

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    Canvas canvas;

    void LoadState()
    {
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        FXVolumeSlider.value = PlayerPrefs.GetFloat("FXVolume", 0f);
    }
    
    void SaveState()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolumeSlider.value);
        PlayerPrefs.SetFloat("FXVolume", FXVolumeSlider.value);
    }

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        LoadState();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    
    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        if (!canvas.enabled)
        {
            SaveState();
            unpaused.TransitionTo(0.01f);
        }
        else
        {
            paused.TransitionTo(0.01f);
        }
    }
    
    public void Quit()
    {
        SaveState();

        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else 
        Application.Quit();
        #endif
    }
}