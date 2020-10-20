using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Brutal Bounce/Skin", order = 0)]
public class Skin : ScriptableObject, IItem
{
    public Sprite sprite;
    private bool bought;
    private int price;

    public bool Bought { get => bought; set => bought = value; }
    public int Price { get => price; set => price = value; }
}