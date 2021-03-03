using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public void GoToLink(string link)
    {
        Application.OpenURL(link);
        Application.Quit();
    }
}
