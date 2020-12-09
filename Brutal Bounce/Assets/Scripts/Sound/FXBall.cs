using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FXBall : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] effects;
    public GameObject particles;


    private void OnCollisionEnter2D(Collision2D other)
    {
        int rand = Random.Range(0, effects.Length);
        audio.clip = (effects[rand]);
        audio.Play();

        if (other.gameObject.tag == "Wall")
        {
            var currentParticles = Instantiate(particles, other.GetContact(0).point, Quaternion.identity);
            Destroy(currentParticles, 1);
        }
    }
}
