using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public GameObject trans;

    public string GameScene;
    public string ShopScene;
    public float time;

    public void ToGameScene()
    {
        Invoke("OpenGameScene", time);
        trans.SetActive(true);
    }
    public void ToShopScene()
    {
        Invoke("OpenShowScene", time);
        trans.SetActive(true);
    }

    public void OpenGameScene()
    {
        SceneManager.LoadScene(GameScene);
    }
    public void OpenShowScene()
    {
        SceneManager.LoadScene(ShopScene);
    }
}
