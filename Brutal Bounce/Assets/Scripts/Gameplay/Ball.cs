using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    GameObject ballInstance;
    GameObject trailInstance;

    [SerializeField] CurrentSkins currentSkins;

    public Rigidbody2D rigidbody;
    CircleCollider2D collider;
    [SerializeField] float velocity = 15;
    [SerializeField] float timeScale = 1;
    bool deactivated = false;

    ScoreManager scoreManager;
    [SerializeField] GameOverPanel gameOverPanel;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        collider = GetComponent<CircleCollider2D>();
    }
    void Start()
    {
        collider.enabled = false;
        var ball = Resources.Load("Balls/" + currentSkins.BallSkinId) as GameObject;
        var trail = Resources.Load("Trails/" + currentSkins.TrailSkinId) as GameObject;
        Instantiate(ball, transform);
        Instantiate(trail, transform);
        if (SceneManager.GetActiveScene().name == "ShopScene")
        {
            GameStarted();
        }
    }
    void Update()
    {
        Time.timeScale = timeScale;
    }

    private void LateUpdate()
    {
        if (!deactivated)
        {
            rigidbody.velocity = velocity * rigidbody.velocity.normalized;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!deactivated)
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
            else if (collision.gameObject.CompareTag("Neighbor")){
                Debug.Log("N");
                InteractionWithNeighbor(collision.gameObject.GetComponent<Neighbor>());
            }   
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

    public void BallCatched()
    {
        deactivated = true;
        collider.enabled = false;
        rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void InteractionWithCoin(Coin coin)
    {
        scoreManager.AddScore(coin.GetValue());
        Destroy(coin.gameObject);
    }
    private void InteractionWithNeighbor(Neighbor neighbor){
        scoreManager.AddScore(neighbor.GetValue());
    }

    public void GameStarted()
    {
        collider.enabled = true;
        rigidbody.gravityScale = 1;
    }
}
