using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    Transform neighbourHolder;
    Animator windowAnimator;
    SpriteRenderer windowSpriteRenderer;
    AudioSource audioSource;

    void Awake()
    {
        neighbourHolder = transform.GetChild(0).GetComponentInChildren<Transform>();
        windowAnimator = GetComponent<Animator>();
        windowSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        CloseWindow();
    }

    public void OpenWindow()
    {
        windowSpriteRenderer.sortingLayerName = "WindowOpen";
        audioSource.Play();
        windowAnimator.Play("OpenWindow");
    }
    public void CloseWindow()
    {
        windowSpriteRenderer.sortingLayerName = "WindowClose";
        windowAnimator.Play("CloseWindow");
    }
}
