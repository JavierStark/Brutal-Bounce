﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    SpriteRenderer sprite;

    ScoreManager scoreManager;

    float horizontalInput;
    [SerializeField] float velocity = 1;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update(){
        GetInput();
    }
    private void FixedUpdate() {
        Vector2 rbVel = new Vector2(horizontalInput, 0)*velocity;
        rigidbody.velocity = rbVel;
    }

    void GetInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            scoreManager.AddScore();
        }
    }
}
