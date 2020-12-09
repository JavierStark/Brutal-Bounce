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
        foreach (ItemInstance item in result.GrantedItems)
        {

        }
    }
    private void RedeemCouponError(PlayFabError error)
    {
        errorText.SetActive(true);
    }
}
