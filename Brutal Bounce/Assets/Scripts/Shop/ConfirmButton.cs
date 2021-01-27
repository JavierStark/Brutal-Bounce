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

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        this.gameObject.SetActive(false);
        shopManager.ConfirmButtonClicked();
    }

    public void SetSelectState()
    {
        gameObject.SetActive(true);
        buttonText.text = "Select";
        buttonImage.color = Color.green;
        button.interactable = true;

        priceText.text = "Bought";
    }
    public void SetBuyState(int price)
    {
        gameObject.SetActive(true);
        buttonText.text = "Buy";
        buttonImage.color = Color.green;
        button.interactable = true;

        priceText.text = price.ToString();
    }
    public void SetNotBuyableState(int price)
    {
        gameObject.SetActive(true);
        buttonText.text = "Buy";
        buttonImage.color = Color.red;
        button.interactable = false;

        priceText.text = price.ToString();
    }

    public void SetPrice(uint price)
    {
        gameObject.SetActive(true);
        priceText.text = price.ToString();
    }

}
