using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ShopManager : MonoBehaviour
{
    [SerializeField] ShopGetter shopGetter;
    [SerializeField] InventoryHandler inventoryHandler;

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
}
