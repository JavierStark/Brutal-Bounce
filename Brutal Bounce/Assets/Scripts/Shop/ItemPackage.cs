using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ItemPackage
{
    public CatalogItem catalogItemReference;
    public ItemUsefulTools.ItemType type;
    public bool bought;

    public void PackageSetup(CatalogItem item, ItemUsefulTools.ItemType type, bool bought)
    {
        catalogItemReference = item;
        this.type = type;
        this.bought = bought;
    }
}
