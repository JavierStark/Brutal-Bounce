using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private bool activ;
    public Animator anim;
    public UserPreferences preferences;

    public Image button;

    public Sprite soundSprite, soundMuteSprite;


    private bool m_sound = true; 

    private void Awake() 
    {
        Time.timeScale = 1;
        m_sound = preferences.mute;
    }

    void FixedUpdate()
    {      
        if(activ)
        {         
            preferences.mute = m_sound;

            if(m_sound)
            {
                button.sprite = soundMuteSprite;
            }else
            {
                button.sprite = soundSprite;        
            }
        }
    }
    public void Activate()
    {
        activ = !activ;           
        anim.SetBool("Activ", activ);
    }
    public void Sound()
    {
        m_sound = !m_sound;      
    }
}
