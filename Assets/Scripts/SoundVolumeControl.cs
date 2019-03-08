using UnityEngine;

public class SoundVolumeControl : MonoBehaviour {
    private AudioSource musicAudioSrc;
    private AudioSource sfxAudioSrc;

    // defaults
    private float musicVolume = 0.5f;
    private float sfxVolume = 0.8f;

    void Start () {
        // TODO make sure sources are being assigned correctly
        musicAudioSrc = GetComponent<AudioSource>();
        sfxAudioSrc = GetComponent<AudioSource>();
    }

    void Update () {
        musicAudioSrc.volume = musicVolume;
        sfxAudioSrc.volume = sfxVolume;
    }

    public void SetMusicVolume(float vol) {
        musicVolume = vol;
    }

    public void SetSfxVolume(float vol) {
        sfxVolume = vol;
    }

    // TODO Reset defaults on click
}