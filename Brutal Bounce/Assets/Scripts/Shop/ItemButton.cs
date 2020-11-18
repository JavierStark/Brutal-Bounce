using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    [SerializeField] GameObject notBoughtPanel;
    [SerializeField] Image previewImage;
    [SerializeField] TMP_Text priceText;
    [SerializeField] GameObject check;
    private bool bought;
    public int index;
    private BuyButtomHandler handler;

    public IItem item;

    public void SetButton(Sprite sprite, string text, bool bought, int index, BuyButtomHandler handler, IItem item, bool selected)
    {
        previewImage.sprite = sprite;
        priceText.text = text;
        this.bought = bought;
        this.index = index;
        this.handler = handler;
        this.item = item;
        handler.OnSkinSelected += DeselectSkin;
        if (!bought)
        {
            notBoughtPanel.SetActive(true);
        }
        else
        {
            notBoughtPanel.SetActive(false);
            if (selected)
            {
                check.SetActive(true);
            }
            else
            {
                check.SetActive(false);
            }
        }


    }

    public void Buy()
    {
        if (!bought)
        {
            handler.Buy(this);
        }
        else
        {
            SelectSkin();
        }

    }

    public void BuyConfirmed()
    {
        bought = true;
        notBoughtPanel.SetActive(false);
    }

    private void SelectSkin()
    {
        handler.SelectSkin(index);
    }

    private void DeselectSkin(int x)
    {
        if (x != index)
        {
            check.SetActive(false);
        }
        else
        {
            check.SetActive(true);
        }
    }

    private void CheckSelection()
    {
        if (handler.GetInfo() == item)
        {
            check.SetActive(true);
        }
        else
        {
            check.SetActive(false);
        }
    }
}
