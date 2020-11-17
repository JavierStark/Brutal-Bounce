using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    public Animator animator;
    private bool activ;


    public void activate(){
        activ = !activ;
        animator.SetBool("Activ", activ);
    }
}
