using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Skins", menuName = "Brutal Bounce/Skins", order = 0)]
public class Skins : ScriptableObject
{
    public List<Sprite> sprites = new List<Sprite>();
    public List<bool> bought = new List<bool>();
}