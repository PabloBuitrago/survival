using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MixLevels : MonoBehaviour {

    public AudioMixer masterMixer;


    public void SetFXVolume(float fxVolume)
    {
        masterMixer.SetFloat("FXVolume", fxVolume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        masterMixer.SetFloat("MusicVolume", musicVolume);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
