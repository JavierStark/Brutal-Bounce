using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] AudioClip menuClip;
    [SerializeField] AudioClip gameClip;
    [SerializeField] AudioClip shopClip;
    [SerializeField] AudioClip creditsClip;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = menuClip;
    }

    public void SetClip(string clipName)
    {
        switch (clipName)
        {
            case "MainMenuScene": audioSource.clip = menuClip; break;
            case "GameScene": audioSource.clip = gameClip; break;
            case "ShopScene": audioSource.clip = shopClip; break;
            case "CreditsScene": audioSource.clip = creditsClip; break;
            default: break;
        }
        audioSource.Play();
    }
}
