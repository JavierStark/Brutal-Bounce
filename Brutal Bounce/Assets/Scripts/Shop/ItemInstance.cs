using UnityEngine;

public class ItemInstance : MonoBehaviour, IItem
{
    public GameObject gameObject;
    public int price;
    public Sprite shopImage;

    public int Price { get => price; set => price = value; }
    public Sprite ShopImage { get => shopImage; set => shopImage = value; }

}