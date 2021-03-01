using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{

    GameObject currentEvent;

    void Start()
    {

    }
    public void GameStarted()
    {
        currentEvent = transform.GetChild(Random.Range(0, transform.childCount)).gameObject;
        currentEvent.SetActive(true);
    }
    public void GameEnded()
    {
        currentEvent.GetComponent<Event>().EventEnded();
    }
}
