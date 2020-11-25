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


    public void SetButton(Sprite sprite, string text, bool bought, int index, BuyButtomHandler handler, bool selected)
    {

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
}
