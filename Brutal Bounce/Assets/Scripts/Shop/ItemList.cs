using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Brutal Bounce/ItemList", order = 0)]
public class ItemList : ScriptableObject
{
    [SerializeField] public List<GameObject> items = new List<GameObject>();
    [SerializeField] public List<bool> bought = new List<bool>();
}
