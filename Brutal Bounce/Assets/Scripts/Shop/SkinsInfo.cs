using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SkinsInfo", menuName = "Brutal Bounce/SkinsInfo", order = 0)]
public class SkinsInfo : ScriptableObject
{
    public ItemInstance ballSkin;
    public PlayerSkin playerSkin;
    public ItemInstance trailSkin;
}