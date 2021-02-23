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
    List<ItemButton> buttons = new List<ItemButton>();

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
            buttons.Add(currentButton.GetComponent<ItemButton>());
        }
        StartCoroutine(CloseLoadWhenReady());
    }

    IEnumerator CloseLoadWhenReady()
    {
        Debug.Log("PreReady");
        yield return new WaitUntil(CheckIfButtonsReady);
        StartCoroutine(LoadManager.Instance.ExitLoading());
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

    private bool CheckIfButtonsReady()
    {
        bool ready = true;
        foreach (ItemButton b in buttons)
        {
            if (!b.IsImageReady())
            {
                ready = false;
            }
        }

        return ready;
    }
}