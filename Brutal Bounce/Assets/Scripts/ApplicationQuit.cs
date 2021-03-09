using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    public Animator animator;
    private bool activ = false;

    public void Interac()
    {
        activ = !activ;
        animator.SetBool("Activ", activ);    
    }
    public void Quit()
    {
        Application.Quit();
    }

}
