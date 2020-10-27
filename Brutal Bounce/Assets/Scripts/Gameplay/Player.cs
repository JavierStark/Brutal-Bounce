using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] SkinsInfo skinsInfo;


    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody;

    ScoreManager scoreManager;

    float horizontalInput;
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
        if (skinsInfo.playerSkin)
        {
            GetComponent<SpriteRenderer>().material = skinsInfo.playerSkin.material;
        }
    }

    void Update()
    {
        GetInput();
        SetAnim();
    }
    private void FixedUpdate()
    {
        Vector2 rbVel = new Vector2(horizontalInput, 0) * velocity;
        rigidbody.velocity = rbVel;
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
}
