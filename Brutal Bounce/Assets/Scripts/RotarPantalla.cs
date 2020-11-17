using UnityEngine;

public class RotarPantalla : MonoBehaviour
{
    private void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;        

    }
}
