using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation : MonoBehaviour
{
    Animator girlAnimator;

    GameObject dialogPanel;
    TMPro.TMP_Text dialogText;

    void Awake()
    {
        girlAnimator = GetComponentInChildren<Animator>();
        dialogPanel = transform.GetChild(1).gameObject;
        dialogText = dialogPanel.GetComponentInChildren<TMPro.TMP_Text>();
    }

    public void NextPart()
    {
        girlAnimator.SetTrigger("Next");
    }
}
