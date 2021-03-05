using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    const string MUSICPPKEY = "MusicVolume";
    const string FXPPKEY = "FXVolume";
    const string MUTEPPKEY = "IsMuted";

    private Animator anim;

    [SerializeField] Image muteButtonCurrentImage;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider fxVolumeSlider;


    [SerializeField] Sprite soundSprite, soundMuteSprite;
    private int muteSound = 0;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void AudioSettingsReset()
    {
        PlayerPrefs.SetInt(MUTEPPKEY, 0);
        PlayerPrefs.SetFloat(MUSICPPKEY, 0.5f);
        PlayerPrefs.SetFloat(FXPPKEY, 0.5f);
        FindObjectOfType<AudioSourceConnector>().AudioSet();
    }

    private void UpdateUI()
    {
        muteSound = PlayerPrefs.GetInt(MUTEPPKEY);
        SetMuteSprite(muteSound);

        musicVolumeSlider.value = PlayerPrefs.GetFloat(MUSICPPKEY);
        fxVolumeSlider.value = PlayerPrefs.GetFloat(FXPPKEY);
    }

    public void OnValueChange(string settingChanged)
    {
        switch (settingChanged)
        {
            case "Mute": PlayerPrefs.SetInt(MUTEPPKEY, muteSound); break;
            case "Fx": PlayerPrefs.SetFloat(FXPPKEY, fxVolumeSlider.value); break;
            case "Music": PlayerPrefs.SetFloat(MUSICPPKEY, musicVolumeSlider.value); break;
            default: break;
        }

        foreach (AudioSourceConnector connector in FindObjectsOfType<AudioSourceConnector>())
        {
            connector.AudioSet();
        }
    }

    public void MuteButtonClicked()
    {
        muteSound = (muteSound == 0 ? 1 : 0);
        OnValueChange("Mute");
        SetMuteSprite(muteSound);
    }

    public void SetMuteSprite(int muteInt)
    {
        if (muteInt == 1)
        {
            muteButtonCurrentImage.sprite = soundMuteSprite;
        }
        else
        {
            muteButtonCurrentImage.sprite = soundSprite;
        }
    }

    public void Open()
    {
        UpdateUI();
        anim.SetBool("Activ", true);
    }

    public void Close()
    {
        anim.SetBool("Activ", false);
    }
}
