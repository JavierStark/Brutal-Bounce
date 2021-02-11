using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panels_Text: MonoBehaviour
{
    public GameObject current;
    public GameObject next;

    public void Call()
    {
        Invoke("Change", 2f);
    }

    void Change()
    {
        current.SetActive(false);
        next.SetActive(true);
    }
}
