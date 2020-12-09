using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System.Linq;

public class CodeRewardPanel : MonoBehaviour
{
    [SerializeField] Image itemImage;
    ItemInstance itemInstance;
    public void SetRewardPanel(ItemInstance item)
    {
        itemInstance = item;
    }

    private void GetShopItem()
    {

    }
    private void GetCatalogItemsSuccess(GetCatalogItemsResult result)
    {

    }
}
