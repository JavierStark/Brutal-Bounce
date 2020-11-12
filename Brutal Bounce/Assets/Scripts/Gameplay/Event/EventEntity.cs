using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEntity : MonoBehaviour
{
    protected Event handlerEvent;
    public void SetToHandlerEvent(Event e)
    {
        handlerEvent = e;
    }
}
