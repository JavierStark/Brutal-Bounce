using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        if (name == "CreditsScene")
        {
            FindObjectOfType<MusicHandler>().SetClip(name);
        }
        SceneManager.LoadScene(name);
    }
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
