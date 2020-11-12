using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarPantalla : MonoBehaviour
{
    private void Start()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        Screen.orientation = ScreenOrientation.AutoRotation;

    }
}
