using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    Presentation presentation;
    void Awake()
    {
        presentation = transform.GetComponentInParent<Presentation>();
    }

    public void AnimFinished()
    {
        presentation.PresentationFinished();
    }
}
