using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceConnector : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioType audioType;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        AudioSet();
    }

    public void AudioSet()
    {
        audioSource.mute = PlayerPrefs.GetInt("IsMuted") == 0 ? false : true;
        if (audioType == AudioType.FX)
        {
            audioSource.volume = PlayerPrefs.GetFloat("FXVolume");
        }
        else
        {
            audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}
