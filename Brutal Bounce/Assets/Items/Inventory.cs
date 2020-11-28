﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    List<ItemInstance> ballInstances = new List<ItemInstance>();
    List<ItemInstance> trailInstances = new List<ItemInstance>();

    public bool ready = false;

    public void InitializeItemsFromServer()
    {
        var request = new GetUserInventoryRequest { };
        PlayFabClientAPI.GetUserInventory(request, InitializeItemsFromServerSuccess, error => { });
    }

    private void InitializeItemsFromServerSuccess(GetUserInventoryResult result)
    {
        List<ItemInstance> trails = new List<ItemInstance>();
        List<ItemInstance> balls = new List<ItemInstance>();

        Debug.Log(result.Inventory.Count);

        foreach (ItemInstance item in result.Inventory)
        {
            if (item.ItemClass == ItemUsefulTools.BallString)
            {
                balls.Add(item);
            }
            else if (item.ItemClass == ItemUsefulTools.TrailString)
            {
                trails.Add(item);
            }
        }

        ballInstances = balls;
        trailInstances = trails;


        ready = true;
    }

    public List<ItemInstance> GetItems(ItemUsefulTools.ItemType type)
    {
        switch (type)
        {
            case ItemUsefulTools.ItemType.Ball: return ballInstances;
            case ItemUsefulTools.ItemType.Trail: return trailInstances;
            default: return null;
        }
    }

    [ContextMenu("Debug")]
    public void DebugItems()
    {
        // foreach (ItemInstance item in itemInstances)
        // {
        //     Debug.Log(item.ItemId);
        // }
    }

}
