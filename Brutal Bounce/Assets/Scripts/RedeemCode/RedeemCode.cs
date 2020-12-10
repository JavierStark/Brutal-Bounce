using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class RedeemCode : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject errorText;

    private bool nextReward = false;

    void Start()
    {
        errorText.SetActive(false);
    }

    public void SubmitCode()
    {
        errorText.SetActive(false);
        var request = new RedeemCouponRequest { CouponCode = inputField.text };
        PlayFabClientAPI.RedeemCoupon(request, RedeemCouponSuccess, RedeemCouponError);
    }

    private void RedeemCouponSuccess(RedeemCouponResult result)
    {
        ShowRewardsCoroutine(result.GrantedItems);
    }

    private IEnumerator ShowRewardsCoroutine(List<ItemInstance> items)
    {
        foreach (ItemInstance item in items)
        {
            //Show Reward
            yield return new WaitUntil(() => nextReward == true);
            nextReward = false;
        }
    }
    private void RedeemCouponError(PlayFabError error)
    {
        errorText.SetActive(true);
    }

    public void RewardPanelClicked()
    {
        nextReward = true;
    }
}
