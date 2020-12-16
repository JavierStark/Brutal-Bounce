using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManagerGetterInRuntime : MonoBehaviour
{
    public void ChangeScene(string scene)
    {
        LoadManager.Instance.ChangeSceneWithLoading(scene);
    }
}
