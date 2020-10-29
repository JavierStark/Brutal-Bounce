using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Event : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsToIntantiate = new List<GameObject>();

    [SerializeField] float maxTimeBtw;
    [SerializeField] float minTimeBtw;

    abstract protected IEnumerator EventInstancingRoutine();

    protected void InstanceEventElement(Vector2 position)
    {
        Instantiate(GetGameObject(), position, Quaternion.identity);
    }

    protected float GetTimeToWait()
    {
        return Random.Range(minTimeBtw, maxTimeBtw);
    }

    protected GameObject GetGameObject()
    {
        return objectsToIntantiate[Random.Range(0, objectsToIntantiate.Count)];
    }

}
