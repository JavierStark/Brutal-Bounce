using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FXBall : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] effects;


    private void OnCollisionEnter2D(Collision2D other) 
    {   
        int rand = Random.Range(0, effects.Length);
        audio.clip = (effects[rand]);   
        audio.Play();
    }
}
