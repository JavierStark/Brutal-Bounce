using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : EventEntity
{
    Window window;
    Animator animator;

    int currentLife = 2;

    CapsuleCollider2D bodyCollider;
    Rigidbody2D rigidbody;


    void Awake()
    {
        window = transform.parent.GetComponentInParent<Window>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = true;
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
            Debug.Log("hit");
            bodyCollider.enabled = false;
            animator.SetTrigger("Dead");
            Destroy(this.gameObject, 6);
        }
        else
        {
            animator.SetTrigger("Collision");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Falling()
    {
        rigidbody.isKinematic = false;
        GetComponent<SpriteRenderer>().sortingLayerName = "Decoracion";
        rigidbody.gravityScale = 1;
    }
}
