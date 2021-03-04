using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayFabLogin : MonoBehaviour
{

    string UserName;

    [SerializeField] GameObject setDisplayNamePanel;
    [SerializeField] GameObject updateRequiredPanel;
    [SerializeField] TMP_Text displayNameText;

    [SerializeField] CoinsManager coinsManager;
    [SerializeField] Settings settings;
    [SerializeField] CurrentSkins currentSkins;

    TMP_InputField displayNameInputField;

    #region Login
    public void Start()
    {
        updateRequiredPanel.SetActive(false);
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
        var request = new GetTitleDataRequest();
        PlayFab.PlayFabClientAPI.GetTitleData(request, GetVersionSuccess, error => { Debug.Log(error.ErrorMessage); });

        if (result.NewlyCreated)
        {
            settings.AudioSettingsReset();
            setDisplayNamePanel.SetActive(true);
            BuyStarterItems();
        }
        else
        {
            LoginCompleted();
        }
    }

    private void GetVersionSuccess(GetTitleDataResult result)
    {
        string version;
        result.Data.TryGetValue("AppVersion", out version);

        if (version != Application.version)
        {
            updateRequiredPanel.SetActive(true);
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
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, SetNameSuccess, error => { Debug.Log(error.ErrorMessage); });

    }

    private void BuyStarterItems()
    {
        var ballRequest = new PurchaseItemRequest { ItemId = "BC000", Price = 0, VirtualCurrency = "BC" };
        var trailRequest = new PurchaseItemRequest { ItemId = "TC000", Price = 0, VirtualCurrency = "BC" };
        PlayFabClientAPI.PurchaseItem(ballRequest, success => { }, error => { Debug.Log(error.ErrorMessage); });
        PlayFabClientAPI.PurchaseItem(trailRequest, success => { }, error => { Debug.Log(error.ErrorMessage); });
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
        PlayFabClientAPI.GetAccountInfo(request, UpdateNameInSceneSuccess, error => { Debug.Log(error.ErrorMessage); });
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
        PlayFab.PlayFabClientAPI.GetTitleData(request, GetDefaultObjectDataSuccess, error => { Debug.Log(error.ErrorMessage); });
    }

    void GetDefaultObjectDataSuccess(GetTitleDataResult result)
    {
        result.Data.TryGetValue("DefaultBallSkinId", out currentSkins.DefaultBall);
        result.Data.TryGetValue("DefaultTrailSkinId", out currentSkins.DefaultTrail);

        var dataRequest = new GetUserDataRequest { Keys = new List<string> { ItemUsefulTools.BallSkinIdString, ItemUsefulTools.TrailSkinIdString } };
        PlayFabClientAPI.GetUserData(dataRequest, GetUserDataSuccess, error => { Debug.Log(error.ErrorMessage); });
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
            currentSkins.BallSkinId = currentBallData.Value;
        }

        if (currentTrailData == null || currentTrailData.Value == null)
        {
            currentSkins.TrailSkinId = currentSkins.DefaultTrail;
        }
        else
        {
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
