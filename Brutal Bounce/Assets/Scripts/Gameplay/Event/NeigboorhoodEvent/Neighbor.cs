using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : EventEntity
{
    void OnDestroy()
    {
        handlerEvent.RoundEnded();
    }
}
