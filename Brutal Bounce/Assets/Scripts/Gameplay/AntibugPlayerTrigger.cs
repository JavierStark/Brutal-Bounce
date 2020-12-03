using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibugPlayerTrigger : MonoBehaviour
{
    [SerializeField] AntibugCollider antibugMaster;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Activate");
        antibugMaster.ActiveCollider();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Deactivate");
        antibugMaster.DeactivateCollider();
    }
}
