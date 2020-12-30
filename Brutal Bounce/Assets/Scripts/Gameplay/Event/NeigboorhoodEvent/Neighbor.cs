using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : EventEntity
{
    Window window;
    Animator animator;

    int currentLife = 2;

    void Awake()
    {
        window = transform.parent.GetComponentInParent<Window>();
        animator = GetComponent<Animator>();
    }
    void OnDestroy()
    {
        window.CloseWindow();
        handlerEvent.RoundEnded();
    }

    public void OpenWindow()
    {
        window.OpenWindow();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentLife--;
        if (currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
        animator.SetTrigger("Collision");
    }
}
