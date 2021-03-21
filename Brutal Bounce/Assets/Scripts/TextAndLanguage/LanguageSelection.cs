using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelection : MonoBehaviour
{
    public void SetLanguage(int n){
        PlayerPrefs.SetInt("Language", n);
    }
}
