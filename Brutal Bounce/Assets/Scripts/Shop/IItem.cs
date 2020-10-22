using UnityEngine;
public interface IItem
{
    bool Bought { get; set; }
    int Price { get; set; }
    Sprite ShopImage { get; set; }
}