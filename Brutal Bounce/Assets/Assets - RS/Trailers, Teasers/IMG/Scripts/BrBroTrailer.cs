using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrBroTrailer : MonoBehaviour
{
    public int limit = 3;
    public int actu;
    public Animator animator;

    public TMP_Text text;

    public string[] info;



    public void Change(){
      
        actu += 1;
        text.text = info[actu].ToString();

        if(actu > limit)
        {
                animator.SetTrigger("End");
        }

    }
    public void End(){
        
    }
}
