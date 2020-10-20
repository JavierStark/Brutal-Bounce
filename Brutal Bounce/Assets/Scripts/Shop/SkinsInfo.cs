using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SkinsInfo", menuName = "Brutal Bounce/SkinsInfo", order = 0)]
public class SkinsInfo : ScriptableObject
{
    public Sprite ballSkin;
    public Sprite playerSkin;
    public GameObject trailSkin;
}