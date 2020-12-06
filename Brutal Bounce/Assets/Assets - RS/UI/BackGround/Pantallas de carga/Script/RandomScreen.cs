using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomScreen : MonoBehaviour
{
    public Image pantalla;
    public Sprite[] screens;

    private void Awake() {

        int rand = Random.Range(0, screens.Length);
        pantalla.sprite = (screens[rand]);
    }
}
