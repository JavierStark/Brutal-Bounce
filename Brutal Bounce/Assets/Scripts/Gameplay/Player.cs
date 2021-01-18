﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody;

    ScoreManager scoreManager;

    float horizontalInput;
    bool gameActive = false;
    [SerializeField] float velocity = 1;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Start()
    {
        StartCoroutine(LoadManager.Instance.ExitLoading());
    }

    void Update()
    {
        if (gameActive)
        {
            GetInput();
            SetAnim();
        }
    }
    private void FixedUpdate()
    {
        if (gameActive)
        {
            Vector2 rbVel = new Vector2(horizontalInput, 0) * velocity;
            rigidbody.velocity = rbVel;
        }
    }

    void GetInput()
    {
        horizontalInput = SimpleInput.GetAxisRaw("Horizontal");
    }

    void SetAnim()
    {
        if (horizontalInput != 0)
        {
            animator.SetBool("Move", true);
            if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            animator.SetTrigger("Collision");
            scoreManager.AddScore();
        }
    }

    public void GameStarted()
    {
        gameActive = true;
    }
    public void GameEnded()
    {
        gameActive = false;
        rigidbody.velocity = new Vector2(0, 0);
        animator.SetTrigger("GameOver");
    }
}
