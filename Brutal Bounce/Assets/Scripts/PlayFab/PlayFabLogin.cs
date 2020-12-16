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

    private void BuyStarterItems()
    {
        var ballRequest = new PurchaseItemRequest { ItemId = "BC000", Price = 0, VirtualCurrency = "BC" };
        var trailRequest = new PurchaseItemRequest { ItemId = "TC000", Price = 0, VirtualCurrency = "BC" };
        PlayFabClientAPI.PurchaseItem(ballRequest, success => { }, error => { });
        PlayFabClientAPI.PurchaseItem(trailRequest, success => { }, error => { });
    }

    private void SetNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        PlayerPrefs.SetInt("USERNAME_SETTED", 1);
        displayNameText.text = result.DisplayName;
        setDisplayNamePanel.SetActive(false);
        BuyStarterItems();
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
            Debug.Log(currentBallData.Value);
            currentSkins.BallSkinId = currentBallData.Value;
        }

        if (currentTrailData == null || currentTrailData.Value == null)
        {
            currentSkins.TrailSkinId = currentSkins.DefaultTrail;
        }
        else
        {
            Debug.Log(currentTrailData.Value);
            currentSkins.TrailSkinId = currentTrailData.Value;
        }

        StartCoroutine(LoadManager.Instance.ExitLoading());
    }





    [ContextMenu("ResetPlayerPrefs")]
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}