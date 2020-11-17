using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    int coins;

    [SerializeField] CoinGetter coinGetter;

    void Start()
    {
        coinGetter.SetCoinsToText();
    }

    public int GetCurrentCoins()
    {
        return coinGetter.GetCoins();
    }

    public void SpendCoins(int coins)
    {
        coinGetter.SpendCoins(coins);
    }
}
