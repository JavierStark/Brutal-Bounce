using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;


    void Awake()
    {
        InitializeInventory();
    }

    void InitializeInventory()
    {
        inventory.InitializeItemsFromServer();
    }

    public List<string> GetItemsID(ItemUsefulTools.ItemType type)
    {
        var items = inventory.GetItems(type);
        List<string> itemsID = new List<string>();
        foreach (ItemInstance item in items)
        {
            itemsID.Add(item.ItemId);
        }

        return itemsID;
    }

    public List<ItemInstance> GetItemsInstances(ItemUsefulTools.ItemType type)
    {
        return inventory.GetItems(type);
    }

    public bool IsReady()
    {
        return inventory.ready;
    }
}
