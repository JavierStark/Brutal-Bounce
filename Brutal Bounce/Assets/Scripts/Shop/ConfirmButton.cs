using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image buttonImage;
    [SerializeField] TMP_Text buttonText;
    [SerializeField] TMP_Text priceText;
    [SerializeField] ShopManager shopManager;

    public void OnClick()
    {
        shopManager.ConfirmButtonClicked();
    }

    public void SetSelectState()
    {
        buttonText.text = "Select";
        buttonImage.color = Color.green;
        button.interactable = true;

        priceText.text = "Bought";
    }
    public void SetBuyState(int price)
    {
        buttonText.text = "Buy";
        buttonImage.color = Color.green;
        button.interactable = true;

        priceText.text = price.ToString();
    }
    public void SetNotBuyableState(int price)
    {
        buttonText.text = "Buy";
        buttonImage.color = Color.red;
        button.interactable = false;

        priceText.text = price.ToString();
    }

    public void SetPrice(uint price)
    {
        priceText.text = price.ToString();
    }

}
