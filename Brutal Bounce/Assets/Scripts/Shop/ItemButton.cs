using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab.ClientModels;
using System;
using UnityEngine.Networking;
using PlayFab;

public class ItemButton : MonoBehaviour
{
    [SerializeField] GameObject notBoughtPanel;
    [SerializeField] Image previewImage;
    [SerializeField] TMP_Text priceText;
    [SerializeField] GameObject selectCheck;
    [SerializeField] GameObject onFocusCheck;

    public ItemPackage item;

    private bool bought;
    private bool selected;
    private BuyButtomHandler handler;


    public void SetButton(ItemPackage itemPackage, bool bought,
    bool selected, BuyButtomHandler handler)
    {
        this.item = itemPackage;
        this.bought = itemPackage.bought;
        this.bought = bought;
        this.selected = selected;
        this.handler = handler;

        handler.shopManager.OnButtonSelectedEvent += CheckFocus;

        uint price;
        price = item.price;
        priceText.text = price.ToString();

        CheckSelection();
        CheckBought();
        StartCoroutine(DownloadImage(item.catalogItemReference.ItemImageUrl));
    }


    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            previewImage.sprite = sprite;
        }
    }

    public void ClickButton()
    {
        handler.SelectSkin(this);
    }

    private void CheckFocus(ItemButton itemButton)
    {
        if (itemButton == this)
        {
            SetFocusState();
        }
        else
        {
            SetNotFocusState();
        }
    }
    private void CheckSelection()
    {
        if (selected)
        {
            SetSelectedState();
        }
        else
        {
            SetDeselectedState();
        }
    }
    private void CheckBought()
    {
        if (bought)
        {
            SetBoughtState();
        }
        else
        {
            SetNotBoughtState();
        }
    }

    private void SetFocusState()
    {
        onFocusCheck.SetActive(true);
    }
    private void SetNotFocusState()
    {
        onFocusCheck.SetActive(false);
    }

    private void SetNotBoughtState()
    {
        notBoughtPanel.SetActive(true);
    }
    private void SetBoughtState()
    {
        notBoughtPanel.SetActive(false);
    }
    private void SetSelectedState()
    {
        selectCheck.SetActive(true);
    }
    private void SetDeselectedState()
    {
        selectCheck.SetActive(false);
    }
}
