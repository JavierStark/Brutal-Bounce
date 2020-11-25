using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    List<ItemInstance> ItemsIDs = new List<ItemInstance>();

    public void InitializeItemsFromServer()
    {
        var request = new GetUserInventoryRequest { };
        PlayFabClientAPI.GetUserInventory(request, InitializeItemsFromServerSuccess, error => { });
    }

    private void InitializeItemsFromServerSuccess(GetUserInventoryResult result)
    {
        ItemsIDs = result.Inventory;
        DebugItems();
    }

    public List<ItemInstance> GetItems()
    {
        return ItemsIDs;
    }

    [ContextMenu("Debug")]
    public void DebugItems()
    {
        foreach (ItemInstance item in ItemsIDs)
        {
            Debug.Log(item.ItemId);
        }
    }

}
