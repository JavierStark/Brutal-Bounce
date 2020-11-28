using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtomHandler : MonoBehaviour
{
    [SerializeField] ItemUsefulTools.ItemType itemType;
    [SerializeField] ShopManager shopManager;
    [SerializeField] GameObject itemButtonPrefab;

    List<ItemPackage> itemPackages;

    void Start()
    {
        StartCoroutine(ConnectWithShopWhenReady());
    }

    public void Buy(ItemButton itemButton)
    {

    }

    public void BuyConfirmed(ItemButton itemButton)
    {
    }


    public void SelectSkin(int index)
    {

    }

    IEnumerator ConnectWithShopWhenReady()
    {
        yield return new WaitUntil(shopManager.IsShopReady);
        itemPackages = shopManager.GetItemPackages(itemType);
    }

    [ContextMenu("Debug")]
    public void DebugItems()
    {
        foreach (ItemPackage item in itemPackages)
        {
            Debug.Log(item.catalogItemReference.DisplayName + " => " + item.catalogItemReference.ItemId + " => " + item.bought);
        }
    }
}