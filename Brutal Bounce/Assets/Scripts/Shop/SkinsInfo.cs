using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SkinsInfo", menuName = "Brutal Bounce/SkinsInfo", order = 0)]
public class SkinsInfo : ScriptableObject
{
    [SerializeField] public Sprite ballSkin;
    [SerializeField] public Sprite playerSkin;
    [SerializeField] public Sprite trailSkin;
}