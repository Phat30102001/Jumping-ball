using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    //public AudioMixerGroup backgroundMixerGroup;
    //public AudioMixerGroup soundEffectMixerGroup;
    public static AudioManager instance;
    public Sound[] sound;

    private void Awake()
    {
        instance= this;

        foreach(Sound s in sound)
        {
            s.audioSource =gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;


            
            //s.audioSource.volume = PlayerPrefs.GetFloat("BackgroundVolume");

            
        }
    }
    public void PlaySound(string name)
    {
        Sound s=Array.Find(sound, sound => sound.name == name);
        s.audioSource.Play();
    }
    public void StopSound(string name)
    {
        Sound s=Array.Find(sound, sound => sound.name == name);
        s.audioSource.Stop();
    }
    //public void UpdateAudioMixerVolume()
    //{
    //    float a = Mathf.Log10(AudioOptionManager.BackgroundVolume) * 20;
    //    backgroundMixerGroup.audioMixer.SetFloat("Background volume", a);
    //    Debug.Log(a);

    //    soundEffectMixerGroup.audioMixer.SetFloat("Sound effect volume", Mathf.Log10(AudioOptionManager.SoundEffectVolume) * 20);
    //}
}
