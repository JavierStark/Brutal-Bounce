using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    [SerializeField] GameObject ball;
    void Start()
    {
        InstantiatePreviewBall();
    }
    public void InstantiatePreviewBall()
    {
        Instantiate(ball, this.transform);
    }
}
