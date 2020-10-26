using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    [SerializeField] SkinsInfo info;
    [SerializeField] Image ballImage;
    Image playerImage;
    Image trailImage;

    void Start()
    {
        ballImage.sprite = info.ballSkin.ShopImage;
    }

    public void Change()
    {
        ballImage.sprite = info.ballSkin.ShopImage;
    }
}
