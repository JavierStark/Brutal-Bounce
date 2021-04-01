using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageSelection : MonoBehaviour
{
    public void SetLanguage(int n){
        PlayerPrefs.SetInt("Language", n);
        SceneManager.LoadScene(1);        
    }
}
