using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public int GetValue()
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, this.transform.position);
        return value;
    }

    void OnDestroy()
    {
    }
}