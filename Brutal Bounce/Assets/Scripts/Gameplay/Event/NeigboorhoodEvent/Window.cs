using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    Transform neighbourHolder;
    Animator windowAnimator;

    void Awake()
    {
        neighbourHolder = transform.GetChild(0).GetComponentInChildren<Transform>();
        windowAnimator = GetComponent<Animator>();
    }

    void OpenWindow()
    {
        windowAnimator.Play("OpenWindow");
    }
    void CloseWindow()
    {
        windowAnimator.Play("CloseWindow");
    }
}
