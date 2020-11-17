using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmBuyPanel : MonoBehaviour
{
    [SerializeField] Image previewImage;
    [SerializeField] TMP_Text infoText;
    [SerializeField] Button button;

    BuyButtomHandler buttonHandler;
    ItemButton itemButton;



    public void SetInformation(BuyButtomHandler handler, ItemButton item, int info)
    {
        buttonHandler = handler;
        itemButton = item;

        previewImage.sprite = itemButton.item.ShopImage;
        if (info == 1)
        {
            infoText.text = "¿Are you sure?";
            button.interactable = true;
            button.GetComponent<Image>().color = Color.green;
        }
        else
        {
            infoText.text = "You have NOT enough coins";
            button.interactable = false;
            button.GetComponent<Image>().color = Color.red;
        }

    }

    public void Confirm()
    {
        buttonHandler.BuyConfirmed(itemButton);
        gameObject.SetActive(false);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
