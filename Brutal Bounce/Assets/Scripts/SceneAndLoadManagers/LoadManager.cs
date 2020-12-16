using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : Singleton<LoadManager>
{
    private SceneHandler sceneHandler;

    private GameObject loadScreen;
    private bool loading = true;


    void Start()
    {
        sceneHandler = GetComponent<SceneHandler>();
        loadScreen = transform.GetChild(0).gameObject;
        loadScreen.SetActive(false);
        StartCoroutine(EnterLoading());
    }


    public IEnumerator EnterLoading()
    {
        loadScreen.SetActive(true);
        loading = true;
        yield break;
    }
    public IEnumerator ExitLoading()
    {
        loadScreen.SetActive(false);
        loading = false;
        yield break;
    }

    public bool IsLoading()
    {
        return loading;
    }

    public void ChangeSceneWithLoading(string scene)
    {
        StartCoroutine(ChangeSceneWithLoadingCoroutine(scene));
    }

    private IEnumerator ChangeSceneWithLoadingCoroutine(string sceneName)
    {
        yield return StartCoroutine(EnterLoading());

        //yield return new WaitForSeconds(segundos de la anim);
        sceneHandler.ChangeScene(sceneName);
        if (sceneName == "GameScene")
        {
            Debug.Log("Ingame");
            yield return StartCoroutine(ExitLoading());
        }
    }
}