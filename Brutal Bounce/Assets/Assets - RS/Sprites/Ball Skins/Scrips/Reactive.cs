using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactive : MonoBehaviour
{
    public Animator animator;
    public AudioSource audio;
    public AudioClip[] effects;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        int rand = Random.Range(0, effects.Length);
        audio.clip = (effects[rand]);   
        
        if(other.gameObject.tag == "Wall")
        {
            animator.SetTrigger("Golpe");
            audio.Play();
        }
    }
}
