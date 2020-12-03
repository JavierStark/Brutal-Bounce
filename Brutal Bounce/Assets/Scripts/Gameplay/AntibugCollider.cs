using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibugCollider : MonoBehaviour
{
    [SerializeField] GameObject ballCollider;

    void Start()
    {
        DeactivateCollider();
    }

    public void ActiveCollider()
    {
        ballCollider.SetActive(true);
    }
    public void DeactivateCollider()
    {
        ballCollider.SetActive(false);
    }
}
