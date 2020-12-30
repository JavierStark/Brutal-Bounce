using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    Transform neighbourHolder;
    Animator windowAnimator;
    SpriteRenderer windowSpriteRenderer;

    void Awake()
    {
        neighbourHolder = transform.GetChild(0).GetComponentInChildren<Transform>();
        windowAnimator = GetComponent<Animator>();
        windowSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        CloseWindow();
    }

    public void OpenWindow()
    {
        windowSpriteRenderer.sortingLayerName = "WindowOpen";
        windowAnimator.Play("OpenWindow");
    }
    public void CloseWindow()
    {
        windowSpriteRenderer.sortingLayerName = "WindowClose";
        windowAnimator.Play("CloseWindow");
    }
}
