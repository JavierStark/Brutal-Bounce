using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody;
    float velocity = 10;
    int noPlayerBounce = 0;
    

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        rigidbody.AddForce(new Vector2(0, -1));
    }
    private void LateUpdate() {
        rigidbody.velocity = velocity * (rigidbody.velocity.normalized);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("UpWall")) {
            
            noPlayerBounce = 0;
            rigidbody.gravityScale = 0;
            float randomX = (Random.Range(0,2) == 0) ? 300 : -300;
            rigidbody.AddForce(-collision.contacts[0].normal +
                    new Vector2(randomX,0));

        }
        else if(collision.gameObject.CompareTag("SideWall")){
            noPlayerBounce++;
            //float randomY = (Random.Range(0,2) == 0) ? 400 : -400;
            //rigidbody.AddForce(-collision.contacts[0].normal +
            //        new Vector2(0, -300));

            if (noPlayerBounce > 4) {
                rigidbody.gravityScale = 1;
                noPlayerBounce = 0;                
            }            
        }
    }
}
