using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ShopGetter : MonoBehaviour
{
    List<CatalogItem> catalogTrails = new List<CatalogItem>();
    List<CatalogItem> catalogBalls = new List<CatalogItem>();

    List<CatalogItem> completeCatalog = new List<CatalogItem>();

    bool ready = false;

    void Start()
    {
        var request = new GetCatalogItemsRequest { };
        PlayFabClientAPI.GetCatalogItems(request, GetCatalogItemsSuccess, error => { });
    }

    void GetCatalogItemsSuccess(GetCatalogItemsResult result)
    {
        List<CatalogItem> trails = new List<CatalogItem>();
        List<CatalogItem> balls = new List<CatalogItem>();

        foreach (CatalogItem item in result.Catalog)
        {
            completeCatalog.Add(item);
            if (item.ItemClass == ItemUsefulTools.BallString)
            {
                balls.Add(item);
            }
            else if (item.ItemClass == ItemUsefulTools.TrailString)
            {
                trails.Add(item);
            }
        }
        catalogBalls = balls;
        catalogTrails = trails;

        ready = true;
    }

    public List<CatalogItem> GetCatalogItems(ItemUsefulTools.ItemType type)
    {
        switch (type)
        {
            case ItemUsefulTools.ItemType.Ball: return catalogBalls;
            case ItemUsefulTools.ItemType.Trail: return catalogTrails;
            default: return null;
        }
    }

    public CatalogItem GetCatalogItemFromID(string id)
    {
        foreach (CatalogItem item in completeCatalog)
        {
            if (item.ItemId == id)
            {
                return item;
            }
        }
        return null;
    }

    public bool IsReady()
    {
        return ready;
    }
}
