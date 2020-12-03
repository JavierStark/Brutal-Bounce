using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class BuyButtomHandler : MonoBehaviour
{
    [SerializeField] ItemUsefulTools.ItemType itemType;
    [SerializeField] ShopManager shopManager;
    [SerializeField] GameObject itemButtonPrefab;

    public delegate void OnButtonSelected(string id);
    public OnButtonSelected OnButtonSelectedEvent;

    List<ItemPackage> itemPackages;

    void Start()
    {
        StartCoroutine(ConnectWithShopWhenReady());
    }

    public void Buy(ItemPackage item)
    {
        var request = new PurchaseItemRequest { ItemId = item.catalogItemReference.ItemId, Price = (int)item.price, VirtualCurrency = "BC" };
        PlayFab.PlayFabClientAPI.PurchaseItem(request, success => { Debug.Log("Success"); }, error => { });
    }

    public void BuyConfirmed(ItemPackage itemButton)
    {
    }


    public void SelectSkin(int index)
    {

    }

    IEnumerator ConnectWithShopWhenReady()
    {
        yield return new WaitUntil(shopManager.IsShopReady);
        itemPackages = shopManager.GetItemPackages(itemType);
        SetupItemsInShop();
    }

    void SetupItemsInShop()
    {
        foreach (ItemPackage itemPackage in itemPackages)
        {
            var currentButton = Instantiate(itemButtonPrefab, transform);
            currentButton.GetComponent<ItemButton>().SetButton(itemPackage, CheckIfBought(itemPackage), CheckSelectedButton(itemPackage), this);
        }
    }

    public bool CheckSelectedButton(ItemPackage item)
    {
        return shopManager.CheckSkinInCurrentSkins(item, itemType);
    }

    public bool CheckIfBought(ItemPackage item)
    {
        return shopManager.CheckIfSkinInInventory(item);
    }

    public void SelectSkin(ItemPackage item)
    {
        OnButtonSelectedEvent(item.catalogItemReference.ItemId);

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