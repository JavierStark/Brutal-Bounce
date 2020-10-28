using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    float minWidth = -9;
    float maxWidth = 9;
    float minHeight = -4;
    float maxHeight = 9;

    Vector2 screenInUnits;

    [SerializeField] GameObject coin;
    [SerializeField] int coinsInGame = 1;

    void Start()
    {
        screenInUnits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < coinsInGame)
        {
            Vector2 newCoinPos = new Vector2(Random.Range(-screenInUnits.x, screenInUnits.x), Random.Range(-screenInUnits.y + (screenInUnits.y / 2), screenInUnits.y));
            Instantiate(coin, newCoinPos, Quaternion.identity, transform);
        }
    }
}
