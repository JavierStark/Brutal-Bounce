using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    GameObject ballInstance;
    GameObject trailInstance;

    [SerializeField] CurrentSkins currentSkins;

    Rigidbody2D rigidbody;
    [SerializeField] float velocity = 15;
    [SerializeField] float timeScale = 1;

    ScoreManager scoreManager;
    [SerializeField] GameOverPanel gameOverPanel;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void Start()
    {
        rigidbody.gravityScale = 0;
        var ball = Resources.Load("Balls/" + currentSkins.BallSkinId) as GameObject;
        var trail = Resources.Load("Trails/" + currentSkins.TrailSkinId) as GameObject;
        Instantiate(ball, transform);
        Instantiate(trail, transform);
    }
    void Update()
    {
        Time.timeScale = timeScale;
    }

    private void LateUpdate()
    {
        rigidbody.velocity = velocity * rigidbody.velocity.normalized;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("UpWall"))
        {
            float randomX = Random.Range(-500f, 500f);
            rigidbody.AddForce(-collision.contacts[0].normal +
                    new Vector2(randomX, 0));
        }
        else if (collision.gameObject.CompareTag("SideWall"))
        {
            float randomY = Random.Range(-500f, 500f);
            rigidbody.AddForce(-collision.contacts[0].normal +
                    new Vector2(0, randomY));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOverCollider"))
        {
            scoreManager.SubmitScoreToServer();
            gameOverPanel.GameOverSetup();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            InteractionWithCoin(collision.gameObject.GetComponent<Coin>());
        }
    }

    private void InteractionWithCoin(Coin coin)
    {
        scoreManager.AddScore(coin.GetValue());
        Destroy(coin.gameObject);
    }

    public void GameStarted()
    {
        rigidbody.gravityScale = 1;
    }
}
