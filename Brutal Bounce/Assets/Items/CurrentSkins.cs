using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

[CreateAssetMenu]
public class CurrentSkins : ScriptableObject
{
    public string BallSkinId;
    public string TrailSkinId;

    public string DefaultBall;
    public string DefaultTrail;

    public void UpdateCurrentSkinsToServer()
    {
        var request = new UpdateUserDataRequest { Data = new Dictionary<string, string> { { ItemUsefulTools.BallSkinIdString, BallSkinId }, { ItemUsefulTools.TrailSkinIdString, TrailSkinId } } };
        PlayFabClientAPI.UpdateUserData(request, success => { }, error => { });
    }
}
