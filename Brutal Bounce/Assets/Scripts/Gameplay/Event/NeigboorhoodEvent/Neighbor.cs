using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : EventEntity
{
    Window window;
    Animator animator;

    int currentLife = 2;

    CapsuleCollider2D bodyCollider;


    void Awake()
    {
        window = transform.parent.GetComponentInParent<Window>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        bodyCollider = GetComponent<CapsuleCollider2D>();
        bodyCollider.isTrigger = true;
    }
    void OnDestroy()
    {
        window.CloseWindow();
        handlerEvent.RoundEnded();
    }

    public void OpenWindow()
    {
        bodyCollider.isTrigger = false;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            animator.SetTrigger("Attack");
        }
    }


}
