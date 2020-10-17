using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody;
    float velocity = 15;
    int noPlayerBounce = 0;
    

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate() {
        rigidbody.velocity = velocity * rigidbody.velocity.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("UpWall")) {
            
            noPlayerBounce = 0;
            float randomX = Random.Range(-500f,500f);
            rigidbody.AddForce(-collision.contacts[0].normal +
                    new Vector2(randomX,0));

        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("GameOverCollider")) {
            print("Change");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
