using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborhoodEvent : Event
{
    [SerializeField] List<Transform> neighbourHolder = new List<Transform>();


    protected override IEnumerator EventInstancingRoutine()
    {
        yield return new WaitForSeconds(GetTimeToWait());
        Neighbor neighbor = InstanceEventElement(GetNeigbourPos()).GetComponent<Neighbor>();
        neighbor.SetToHandlerEvent(this);
        yield return new WaitUntil(() => roundFinished == true);
    }

    private Transform GetNeigbourPos()
    {
        return neighbourHolder[Random.Range(0, neighbourHolder.Count)];
    }
}
