using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [SerializeField] int itemIndex;
    [SerializeField] IItem skins;

    [SerializeField] Image itemImage;
    [SerializeField] GameObject notBoughtPanel;

    void Start()
    {

    }

    public void SetIndex(int index)
    {
        itemIndex = index;
    }

}
