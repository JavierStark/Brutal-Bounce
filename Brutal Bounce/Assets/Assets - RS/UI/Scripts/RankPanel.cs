using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : MonoBehaviour
{
    public Animator panelRank;
    public bool activP;



    public void Interact()
    {
        activP = !activP;
        panelRank.SetBool("Activ", activP);
    }
}
