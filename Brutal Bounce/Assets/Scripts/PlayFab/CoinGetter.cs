using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class CoinGetter : MonoBehaviour
{
    int coins;

    public void SetCoinsToText()
    {
        var request = new GetPlayerStatisticsRequest { StatisticNames = new List<string>() { "Coin" } };
        PlayFabClientAPI.GetPlayerStatistics(request, success =>
        {
            Debug.Log(coins);
            coins = success.Statistics[0].Value;
            Debug.Log(coins);
            UpdateText();
        },
        error =>
        {
            coins = 0;
            Debug.Log("error");
        });
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SpendCoins(int coinsToSpend)
    {
        LoadCoinsToServer(coinsToSpend);
        coins -= coinsToSpend;
        UpdateText();
    }

    public void LoadCoinsToServer(int scoreToSpend)
    {
        Debug.Log(coins);
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>() {
                new StatisticUpdate {StatisticName = "Coin", Value = -scoreToSpend }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, success => { }, error => { });
    }

    void UpdateText()
    {
        GetComponent<TMP_Text>().text = coins.ToString();
    }
}
