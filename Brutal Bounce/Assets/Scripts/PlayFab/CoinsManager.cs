using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class CoinsManager : MonoBehaviour
{
    const string CURRENCYID = "BC";

    int currency = 0;

    public void GetCurrencyFromServer()
    {
        var request = new GetUserInventoryRequest { };
        PlayFabClientAPI.GetUserInventory(request, GetCurrencySuccess, error => { Debug.Log(error.ErrorMessage); });
    }

    void GetCurrencySuccess(GetUserInventoryResult result)
    {
        int currencyValueGetted;
        result.VirtualCurrency.TryGetValue(CURRENCYID, out currencyValueGetted);
        currency = currencyValueGetted;
        Debug.Log(currency);
    }

    public int GetCoins()
    {
        return currency;
    }

    public bool SpendCoins(uint coinsToSpend)
    {

        if (currency - coinsToSpend >= 0)
        {
            var request = new SubtractUserVirtualCurrencyRequest { Amount = (int)coinsToSpend, VirtualCurrency = CURRENCYID };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, SpendCoinsSuccess, error => { });
            return true;
        }
        else
        {
            return false;
        }
    }

    void SpendCoinsSuccess(ModifyUserVirtualCurrencyResult result)
    {
        currency = result.Balance;
        Debug.Log(currency);
    }

    public void SetUserName()
    {

    }

}
