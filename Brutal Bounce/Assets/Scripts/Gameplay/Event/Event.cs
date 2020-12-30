using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Event : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsToIntantiate = new List<GameObject>();

    [SerializeField] float maxTimeBtw;
    [SerializeField] float minTimeBtw;

    protected bool roundFinished = false;
    protected bool eventFinished = false;

    void Start()
    {
        StartCoroutine(EventInstancingRoutine());
    }

    abstract protected IEnumerator EventInstancingRoutine();

    protected GameObject InstanceEventElement(Transform whereToInstantiate)
    {
        return Instantiate(GetGameObject(), whereToInstantiate.position, Quaternion.identity, whereToInstantiate);
    }

    protected float GetTimeToWait()
    {
        return Random.Range(minTimeBtw, maxTimeBtw);
    }

    protected GameObject GetGameObject()
    {
        return objectsToIntantiate[Random.Range(0, objectsToIntantiate.Count)];
    }

    public void RoundEnded()
    {
        roundFinished = true;
    }

    public void EventEnded()
    {
        eventFinished = true;
    }
}
