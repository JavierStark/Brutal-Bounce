using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FXBall : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] effects;
    public ParticleSystem particle;


    private void OnCollisionEnter2D(Collision2D other) 
    {   
        particle.Play();
        int rand = Random.Range(0, effects.Length);
        audio.clip = (effects[rand]);   
        audio.Play();
    }
}
