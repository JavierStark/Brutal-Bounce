using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public GameObject trans;

    public string scene;
    public float time;

    public void entry()
    {
        Invoke("OpenScene", time);
        trans.SetActive(true);
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(scene);
    }
}
