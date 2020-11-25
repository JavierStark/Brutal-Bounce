using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab.ClientModels;
using System;

public class ItemButton : MonoBehaviour
{
    [SerializeField] GameObject notBoughtPanel;
    [SerializeField] Image previewImage;
    [SerializeField] TMP_Text priceText;
    [SerializeField] GameObject pricePanel;

    CatalogItem item;

    private bool bought;
    private bool selected;
    private BuyButtomHandler handler;


    public void SetButton(CatalogItem item, bool bought, bool selected, BuyButtomHandler handler)
    {
        this.item = item;
        this.bought = bought;
        this.selected = selected;
        this.handler = handler;

        previewImage.sprite = GetImageFromWeb(item.ItemImageUrl);
        uint price;
        item.VirtualCurrencyPrices.TryGetValue("BC", out price);
        priceText.text = price.ToString();

        CheckSelection();
        CheckBought();
    }


    Sprite GetImageFromWeb(string url)
    {
        return null;
    }

    public void Buy()
    {


    }

    public void BuyConfirmed()
    {

    }

    private void SelectSkin()
    {

    }

    private void DeselectSkin(int x)
    {

    }

    private void CheckSelection()
    {

    }
    private void CheckBought()
    {
        throw new NotImplementedException();
    }
}
