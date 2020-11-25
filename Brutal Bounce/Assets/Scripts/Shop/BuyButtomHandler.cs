using System;
using UnityEngine;

public class BuyButtomHandler : MonoBehaviour
{
    [SerializeField] GameObject confirmBuyPanel;

    public event Action<int> OnSkinSelected;

    void Start()
    {

    }

    public void Buy(ItemButton itemButton)
    {

    }

    public void BuyConfirmed(ItemButton itemButton)
    {
    }


    public void SelectSkin(int index)
    {

    }
}