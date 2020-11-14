using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] Animator openCloseAnim;
    [SerializeField] GameObject setDisplayNamePanel;
    [SerializeField] TMP_Text displayNameText;
    [SerializeField] CoinGetter coinGetter;
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
            UpdateNameInScene();
            coinGetter.SetCoinsToText();
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
    }

    private void UpdateNameInScene()
    {
        var request = new GetAccountInfoRequest { };
        PlayFabClientAPI.GetAccountInfo(request, UpdateNameInSceneSuccess, error => { });
    }
    private void UpdateNameInSceneSuccess(GetAccountInfoResult result)
    {
        displayNameText.text = result.AccountInfo.TitleInfo.DisplayName;
        openCloseAnim.SetTrigger("Abrir");
    }

    #endregion Name

    [ContextMenu("ResetPlayerPrefs")]
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}