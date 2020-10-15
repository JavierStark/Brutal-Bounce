using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    SpriteRenderer sprite;

    float horizontalInput;
    [SerializeField] float velocity = 1;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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
}
