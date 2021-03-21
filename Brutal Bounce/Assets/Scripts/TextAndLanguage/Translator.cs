using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    [SerializeField] Multilanguage multilanguageScriptableObject;

    [SerializeField] int textID;
    TMPro.TMP_Text text;    

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start()
    {
        text.text = multilanguageScriptableObject.textItems[textID].translation[PlayerPrefs.GetInt("Language")];
    }
}