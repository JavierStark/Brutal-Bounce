using System;
using UnityEngine;

public class BuyButtomHandler : MonoBehaviour
{

    [SerializeField] ItemType type;

    [SerializeField] ItemList itemList;
    [SerializeField] GameObject buttomPrefab;
    [SerializeField] Preview skinsPreview;
    [SerializeField] SkinsInfo info;
    [SerializeField] ShopManager shopManager;

    public event Action<int> OnSkinSelected;

    void Start()
    {
        int index = 0;
        foreach (GameObject item in itemList.items)
        {
            GameObject currentButton = Instantiate(buttomPrefab, transform);
            ItemButton button = currentButton.GetComponent<ItemButton>();
            IItem convertedItem = item.GetComponent<IItem>();

            button.SetButton(convertedItem.ShopImage,
                            convertedItem.Price.ToString(),
                            itemList.bought[index],
                            index,
                            this,
                            convertedItem);

            index++;
        }
    }

    public bool Buy(int index)
    {
        if (itemList.bought[index] != true)
        {
            itemList.bought[index] = true;
            int price = itemList.items[index].GetComponent<ItemInstance>().price;

            if (shopManager.GetCurrentCoins() >= price)
            {
                shopManager.SpendCoins(price);
                return true;
            }
        }
        return false;
    }

    public void SelectSkin(int index)
    {
        OnSkinSelected(index);
        IItem currentItem = itemList.items[index].GetComponent<IItem>();

        switch (type)
        {
            case ItemType.Ball: info.ballSkin = (ItemInstance)currentItem; break;
            case ItemType.Trail: info.trailSkin = (ItemInstance)currentItem; break;
            case ItemType.Player: info.playerSkin = (PlayerSkin)currentItem; break;
        }

        skinsPreview.Change();
    }

    public IItem GetInfo()
    {
        switch (type)
        {
            case ItemType.Ball:
                return info.ballSkin;
            case ItemType.Player:
                return info.playerSkin;
            case ItemType.Trail:
                return info.trailSkin;
            default: return null;
        }
    }
}