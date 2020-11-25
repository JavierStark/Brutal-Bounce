using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public SpriteRenderer building;

    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = building.bounds.size.x / building.bounds.size.y;

        if(screenRatio >= targetRatio){
            Camera.main.orthographicSize = building.bounds.size.y / 2;
        }else{
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = building.bounds.size.y / 2 * differenceInSize;
        }
    }

}
