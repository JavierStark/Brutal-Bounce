using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour
{
    public UserPreferences preferences;

    public Slider music, fX;

    void Start()
    {
        fX.value = preferences.fXVolume;
        music.value = preferences.musicVolume;
    }

    public void ValueFx()
    {
        preferences.fXVolume = fX.value;
    }
        public void ValueMusic()
    {
        preferences.musicVolume = music.value;
    }
}
