using UnityEngine;

[CreateAssetMenu(fileName = "Trail", menuName = "Brutal Bounce/Trail", order = 0)]
public class Trail : ScriptableObject, IItem
{
    public GameObject trail;
    private bool bought;
    private int price;

    public bool Bought { get => bought; set => bought = value; }
    public int Price { get => price; set => price = value; }
}