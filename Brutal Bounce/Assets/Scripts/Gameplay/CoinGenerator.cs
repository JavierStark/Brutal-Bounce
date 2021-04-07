using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    Vector2 screenInUnits;

    [SerializeField] GameObject coin;
    [SerializeField] int coinsInGame = 1;
    [SerializeField] float instantiateDelay = 1;    
    


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
            var currentCoin = (Instantiate(coin, newCoinPos, Quaternion.identity, transform));
            StartCoroutine(ActivateCoinWithDelay(currentCoin));
        }
    }

    IEnumerator ActivateCoinWithDelay(GameObject coin)
    {
        coin.SetActive(false);
        yield return new WaitForSeconds(instantiateDelay);
        coin.SetActive(true);
    }
}
