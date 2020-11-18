using UnityEngine;
using TMPro;

public class CreditsScript : MonoBehaviour
{

    public Animator animator;
    public TMP_Text textC;
    
    public int act;
    public int limit = 6;

    [TextArea(1, 5)]
    public string[] credits;

    public void Change()
    {
        
        act += 1;
        textC.text = credits[act].ToString();

        if(act == limit)
        {
            animator.SetTrigger("End");
        }
    }

    public void ChangeScene(string scene)
    {
         Application.LoadLevel(scene);         
    }
}
