using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class BuyButtomHandler : MonoBehaviour
{
    [SerializeField] ItemUsefulTools.ItemType itemType;
    [SerializeField] public ShopManager shopManager;
    [SerializeField] GameObject itemButtonPrefab;


    List<ItemPackage> itemPackages;

    void Start()
    {
        StartCoroutine(ConnectWithShopWhenReady());
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

    public void SelectSkin(ItemButton itemButton)
    {
        shopManager.SetCurrentOnFocusItem(itemButton);
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