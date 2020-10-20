using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiple_Trail : MonoBehaviour
{
    private float timeSpawn;
    public float startTimeSpawn = 0.1f;
    public float destroyTime = 5f;

    public GameObject[] trail;
    
    void Update()
    {
        if(timeSpawn <= 0)
        {
            int rand = Random.Range(0, trail.Length);
            GameObject instance = (GameObject)Instantiate(trail[rand], transform.position, Quaternion.identity);
            Destroy(instance, destroyTime);
            timeSpawn = startTimeSpawn;
        }else{
            timeSpawn -= Time.deltaTime;
        }
    }
}
