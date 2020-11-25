using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    public Material material;
    public int price;
    public Sprite shopImage;

    public int Price { get => price; set => price = value; }
    public Sprite ShopImage { get => shopImage; set => shopImage = value; }

}