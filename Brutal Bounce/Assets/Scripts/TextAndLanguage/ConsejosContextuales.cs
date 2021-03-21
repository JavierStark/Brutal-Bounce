using UnityEngine;
using TMPro;

public class ConsejosContextuales : MonoBehaviour
{

    public TMP_Text textC;

    [SerializeField] Multilanguage multiLanguage;
    [SerializeField] int firstTip;
    [SerializeField] int secondTip;

    
    public void NewTip()
    {
        int rand = Random.Range(firstTip, secondTip);
        textC.text = multiLanguage.textItems[rand].translation[PlayerPrefs.GetInt("Language")];
    }
}
