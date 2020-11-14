using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionTrail : MonoBehaviour
{
    public GameObject prefab;
    public float destroyTime = 5f;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            GameObject instance = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(instance, destroyTime);
            Destroy(gameObject);
        }
    }
}
