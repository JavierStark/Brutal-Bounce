using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ShopGetter : MonoBehaviour
{
    List<CatalogItem> catalogItems = new List<CatalogItem>();
    InventoryHandler inventoryHandler;

    void Awake()
    {
        inventoryHandler = GetComponent<InventoryHandler>();
    }

    void Start()
    {
        var request = new GetCatalogItemsRequest { };
        PlayFabClientAPI.GetCatalogItems(request, GetCatalogItemsSuccess, error => { });
    }

    void GetCatalogItemsSuccess(GetCatalogItemsResult result)
    {
        catalogItems = result.Catalog;
        DebugItems();
    }

    void DebugItems()
    {
        foreach (CatalogItem item in catalogItems)
        {
            if (inventoryHandler.GetItemsID().Contains(item.ItemId))
            {
                Debug.Log(item.ItemId + "   YES");
            }
            else
            {
                Debug.Log(item.ItemId + "   NO");
            }
        }
    }
}
