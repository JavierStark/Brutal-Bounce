using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : Singleton<LoadManager>
{
    private SceneHandler sceneHandler;

    void Start()
    {
        sceneHandler = GetComponent<SceneHandler>();
    }

    private bool loading = true;

    public IEnumerator EnterLoading()
    {
        //Close Panel
        loading = true;
        yield break;
    }
    public IEnumerator ExitLoading()
    {
        //Open Panel
        loading = false;
        yield break;
    }

    public bool IsLoading()
    {
        return loading;
    }

    public IEnumerator ChangeSceneWithLoading(string sceneName)
    {
        yield return StartCoroutine(EnterLoading());

        //yield return new WaitForSeconds(segundos de la anim);
        sceneHandler.ChangeScene(sceneName);

        yield return StartCoroutine(ExitLoading());
    }
}