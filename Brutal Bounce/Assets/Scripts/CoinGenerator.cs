using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    const float minWidth = -9;
    const float maxWidth = 9;
    const float minHeight = -4;
    const float maxHeight = 9;

    [SerializeField] GameObject coin;
    [SerializeField] int coinsInGame = 1;




    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < coinsInGame) {
            Vector2 newCoinPos = new Vector2(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight));
            Instantiate(coin, newCoinPos, Quaternion.identity, transform);
        }
    }
}
