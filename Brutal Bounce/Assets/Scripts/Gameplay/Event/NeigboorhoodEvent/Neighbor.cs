using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : EventEntity
{
    Window window;
    Animator animator;

    int currentLife = 2;

    Collider2D collider;

    void Awake()
    {
        window = transform.parent.GetComponentInParent<Window>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }
    void OnDestroy()
    {
        window.CloseWindow();
        handlerEvent.RoundEnded();
    }

    public void OpenWindow()
    {
        collider.isTrigger = false;
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
