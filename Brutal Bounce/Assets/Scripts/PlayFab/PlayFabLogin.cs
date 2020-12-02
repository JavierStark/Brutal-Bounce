using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayFabLogin : MonoBehaviour
{

    string UserName;

    [SerializeField] Animator openCloseAnim;
    [SerializeField] GameObject setDisplayNamePanel;
    [SerializeField] TMP_Text displayNameText;

    [SerializeField] CoinsManager coinsManager;
    [SerializeField] CurrentSkins currentSkins;

    TMP_InputField displayNameInputField;

    #region Login
    public void Start()
    {
        setDisplayNamePanel.SetActive(false);
        displayNameInputField = setDisplayNamePanel.GetComponentInChildren<TMP_InputField>();
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = "44BCB";
        }

        var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = ReturnAndroidID(), CreateAccount = true };
        PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        if (PlayerPrefs.GetInt("USERNAME_SETTED") != 1)
        {
            openCloseAnim.SetTrigger("Abrir");
            setDisplayNamePanel.SetActive(true);
        }
        else
        {
            LoginCompleted();
        }
    }


    private void OnLoginFailure(PlayFabError error)
    {
        Application.Quit();
    }
    private static string ReturnAndroidID()
    {
        return SystemInfo.deviceUniqueIdentifier;
    }
    #endregion Login
    #region Name

    public void SetDisplayName()
    {
        string name = displayNameInputField.text;

        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = name };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, SetNameSuccess, error => { });
    }

    private void SetNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        PlayerPrefs.SetInt("USERNAME_SETTED", 1);
        displayNameText.text = result.DisplayName;
        setDisplayNamePanel.SetActive(false);
        LoginCompleted();
    }

    private void UpdateNameInScene()
    {
        var request = new GetAccountInfoRequest { };
        PlayFabClientAPI.GetAccountInfo(request, UpdateNameInSceneSuccess, error => { });
    }
    private void UpdateNameInSceneSuccess(GetAccountInfoResult result)
    {
        displayNameText.text = result.AccountInfo.TitleInfo.DisplayName;
    }

    #endregion Name

    void LoginCompleted()
    {
        UpdateNameInScene();
        coinsManager.GetCurrencyFromServer();
        openCloseAnim.SetTrigger("Abrir");

        var request = new GetTitleDataRequest();
        PlayFab.PlayFabClientAPI.GetTitleData(request, GetTitleDataSuccess, error => { });
    }

    void GetTitleDataSuccess(GetTitleDataResult result)
    {
        result.Data.TryGetValue("DefaultBallSkinId", out currentSkins.DefaultBall);
        result.Data.TryGetValue("DefaultTrailSkinId", out currentSkins.DefaultTrail);

        var request = new GetUserDataRequest { Keys = new List<string> { ItemUsefulTools.BallSkinIdString, ItemUsefulTools.TrailSkinIdString } };
        PlayFabClientAPI.GetUserData(request, GetUserDataSuccess, error => { });
    }


    void GetUserDataSuccess(GetUserDataResult result)
    {
        foreach (KeyValuePair<string, UserDataRecord> data in result.Data)
        {
            Debug.Log(data.Key + " " + data.Value);
        }
        UserDataRecord currentBallData = null;
        result.Data.TryGetValue(ItemUsefulTools.BallSkinIdString, out currentBallData);

        UserDataRecord currentTrailData = null;
        result.Data.TryGetValue(ItemUsefulTools.TrailSkinIdString, out currentTrailData);

        if (currentBallData == null || currentBallData.Value == null)
        {
            currentSkins.BallSkinId = currentSkins.DefaultBall;
        }
        else
        {
            currentSkins.BallSkinId = currentBallData.Value;
        }

        if (currentTrailData == null || currentTrailData.Value == null)
        {
            currentSkins.TrailSkinId = currentSkins.DefaultTrail;
        }
        else
        {
            currentSkins.TrailSkinId = currentBallData.Value;
        }
    }





    [ContextMenu("ResetPlayerPrefs")]
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}