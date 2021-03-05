using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ShopManager : MonoBehaviour
{
    ShopGetter shopGetter;
    InventoryHandler inventoryHandler;
    CoinsManager coinsManager;
    [SerializeField] CurrentSkins currentSkins;

    [SerializeField] ConfirmButton confirmButton;

    ItemButton currentInFocusItem;

    public delegate void OnButtonSelected(ItemButton itemButton);
    public OnButtonSelected OnButtonSelectedEvent;

    void Start()
    {
        shopGetter = GetComponent<ShopGetter>();
        inventoryHandler = GetComponent<InventoryHandler>();
        coinsManager = GetComponent<CoinsManager>();
        coinsManager.GetCurrencyFromServer();
    }

    public List<ItemPackage> GetItemPackages(ItemUsefulTools.ItemType type)
    {
        if (!IsShopReady()) return null;

        List<CatalogItem> shopItems = shopGetter.GetCatalogItems(type);
        List<string> inventoryItems = inventoryHandler.GetItemsID(type);

        List<ItemPackage> packages = new List<ItemPackage>();

        foreach (string item in inventoryItems)
        {
            Debug.Log(item);
        }

        foreach (CatalogItem catalogItem in shopItems)
        {
            ItemPackage package = new ItemPackage();

            bool bought = false;

            if (inventoryItems.Contains(catalogItem.ItemId))
            {
                bought = true;
            }

            package.PackageSetup(catalogItem, type, bought);

            packages.Add(package);
        }

        return packages;
    }

    public bool IsShopReady()
    {
        return (shopGetter.IsReady() && inventoryHandler.IsReady());
    }

    public void SetCurrentOnFocusItem(ItemButton item)
    {
        currentInFocusItem = item;
        OnButtonSelectedEvent(item);
        UpdateConfirmButtonState();
    }
    private void UpdateConfirmButtonState()
    {
        if (currentInFocusItem.item.bought)
        {
            confirmButton.SetSelectState();
        }
        else
        {
            Debug.Log("Price " + currentInFocusItem.item.price + "    Coins " + coinsManager.GetCoins());
            if (coinsManager.GetCoins() >= currentInFocusItem.item.price)
            {
                confirmButton.SetBuyState((int)currentInFocusItem.item.price);
            }
            else
            {
                confirmButton.SetNotBuyableState((int)currentInFocusItem.item.price);
            }
        }
    }

    public void Buy()
    {
        var request = new PurchaseItemRequest { ItemId = currentInFocusItem.item.catalogItemReference.ItemId, Price = (int)currentInFocusItem.item.price, VirtualCurrency = "BC" };
        PlayFab.PlayFabClientAPI.PurchaseItem(request, BuySuccess, error => { });
    }

    private void BuySuccess(PurchaseItemResult result)
    {
        ReloadScene();
    }

    public void ConfirmButtonClicked()
    {
        if (currentInFocusItem.item.bought)
        {
            SelectItemInFocus();
        }
        else
        {
            Buy();
        }
    }

    private void SelectItemInFocus()
    {
        switch (currentInFocusItem.item.type)
        {
            case ItemUsefulTools.ItemType.Ball: currentSkins.BallSkinId = currentInFocusItem.item.catalogItemReference.ItemId; break;
            case ItemUsefulTools.ItemType.Trail: currentSkins.TrailSkinId = currentInFocusItem.item.catalogItemReference.ItemId; break;
        }
        currentSkins.UpdateCurrentSkinsToServer();
        ReloadScene();
    }

    private void ReloadScene()
    {
        LoadManager.Instance.ChangeSceneWithLoading("ShopScene");
    }

    public bool CheckSkinInCurrentSkins(ItemPackage skin, ItemUsefulTools.ItemType type)
    {
        switch (type)
        {
            case ItemUsefulTools.ItemType.Ball:
                if (skin.catalogItemReference.ItemId == currentSkins.BallSkinId)
                {
                    return true;
                }
                return false;
            case ItemUsefulTools.ItemType.Trail:
                if (skin.catalogItemReference.ItemId == currentSkins.TrailSkinId)
                {
                    return true;
                }
                return false;
            default: return false;
        }
    }

    public bool CheckIfSkinInInventory(ItemPackage item)
    {
        return inventoryHandler.ItemInInventory(item);
    }
}
