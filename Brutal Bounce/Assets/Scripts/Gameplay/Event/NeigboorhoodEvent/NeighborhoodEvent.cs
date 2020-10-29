using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborhoodEvent : Event
{
    [SerializeField] List<Transform> windowsPos = new List<Transform>();


    protected override IEnumerator EventInstancingRoutine()
    {
        yield return new WaitForSeconds(GetTimeToWait());
    }

    private Vector2 GetWindowPos()
    {
        return windowsPos[Random.Range(0, windowsPos.Count)].position;
    }
}
