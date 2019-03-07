using UnityEngine;

public class SoundVolumeControl : MonoBehaviour {

    // Reference to Audio Source component
    private AudioSource musicAudioSrc;
    private AudioSource sfxAudioSrc;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float musicVolume = 0.5f;
    private float sfxVolume = 0.8f;

    // Use this for initialization
    void Start () {

        // Assign Audio Source component to control it
        musicAudioSrc = GetComponent<AudioSource>();
        sfxAudioSrc = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update () {

        // Setting volume option of Audio Source to be equal to musicVolume
        musicAudioSrc.volume = musicVolume;
        sfxAudioSrc.volume = sfxVolume;
    }

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetMusicVolume(float vol)
    {
        musicVolume = vol;
    }

    public void SetSfxVolume(float vol)
    {
        sfxVolume = vol;
    }

    // TODO Reset defaults on click
}