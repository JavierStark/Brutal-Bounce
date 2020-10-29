using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> events = new List<GameObject>();
    GameObject currentEvent;

    void Start()
    {
        currentEvent = Instantiate(events[Random.Range(0, events.Count)], transform);
    }
}
