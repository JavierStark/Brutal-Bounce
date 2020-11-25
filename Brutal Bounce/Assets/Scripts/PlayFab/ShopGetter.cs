﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ShopGetter : MonoBehaviour
{
    List<CatalogItem> catalogItems = new List<CatalogItem>();

    void Start()
    {
        var request = new GetCatalogItemsRequest { };
        PlayFabClientAPI.GetCatalogItems(request, GetCatalogItemsSuccess, error => { });
    }

    void GetCatalogItemsSuccess(GetCatalogItemsResult result)
    {
        catalogItems = result.Catalog;
    }
}
