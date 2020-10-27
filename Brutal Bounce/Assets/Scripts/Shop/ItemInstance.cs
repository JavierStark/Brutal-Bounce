using UnityEngine;

public class ItemInstance : MonoBehaviour, IItem
{
    public GameObject gameObject;
    private bool bought;
    public int price;
    public Sprite shopImage;

    public bool Bought { get => bought; set => bought = value; }
    public int Price { get => price; set => price = value; }
    public Sprite ShopImage { get => shopImage; set => shopImage = value; }

}